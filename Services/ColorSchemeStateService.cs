using ModuleManagement.Web.Client.Models;
using System;

namespace ModuleManagement.Web.Client.Services
{
    public class ColorSchemeStateService
    {
        public ColorScheme CurrentColorScheme { get; private set; } = new ColorScheme();

        public event Action OnChange;

        public void SetColorScheme(ColorScheme scheme)
        {
            CurrentColorScheme = scheme;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
