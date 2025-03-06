public class ValidationMessageService
{
    private readonly LanguageService _languageService;

    public ValidationMessageService(LanguageService languageService)
    {
        _languageService = languageService;
    }

    public string GetErrorMessage(string key)
    {
        return _languageService.Translate(key);
    }
}