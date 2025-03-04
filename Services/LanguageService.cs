using Microsoft.JSInterop;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

public class LanguageService
{
    private readonly HttpClient _http; // Manténlo si lo necesitas para otros fines
    private readonly IJSRuntime _js;
    private Dictionary<string, string> _translations = new();
    private string _currentLanguage = "es"; // Idioma por defecto
    public string CurrentLanguage => _currentLanguage;

    public event Action OnLanguageChanged;

    private readonly ILogger<LanguageService> _logger;

    public LanguageService(HttpClient http, IJSRuntime js, ILogger<LanguageService> logger)
    {
        _http = http;
        _js = js;
        _logger = logger;
    }

    public async Task LoadLanguageAsync(string language)
    {
        language = language.Trim();
        _currentLanguage = language;
        try
        {
            // Usar IJSRuntime para leer el archivo JSON desde wwwroot
            var json = await _js.InvokeAsync<string>("fetchJsonFile", $"locales/{language}.json");
            _translations = JsonSerializer.Deserialize<Dictionary<string, string>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                ?? new Dictionary<string, string>();
            _logger.LogInformation($"Language '{language}' loaded successfully.");
            OnLanguageChanged?.Invoke();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error loading language '{language}'.");
            _translations = new Dictionary<string, string>();
        }
    }

    public string Translate(string key)
    {
        if (_translations == null || !_translations.ContainsKey(key))
        {
            Console.WriteLine($"Key '{key}' not found for language '{_currentLanguage}'.");
            return key; // Retorna la clave si no se encuentra
        }
        return _translations[key];
    }

    public async Task SetLanguage(string language)
    {
        await _js.InvokeVoidAsync("localStorage.setItem", "language", language);
        await LoadLanguageAsync(language);
    }

    public async Task<string> GetStoredLanguageAsync()
    {
        var storedLang = await _js.InvokeAsync<string>("localStorage.getItem", "language");
        return string.IsNullOrEmpty(storedLang) ? "es" : storedLang.Trim();
    }
}