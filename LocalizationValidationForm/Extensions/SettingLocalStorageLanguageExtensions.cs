using System.Globalization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace LocalizationValidationForm.Extensions;

public static class SettingLocalStorageLanguageExtensions
{
    public static async Task<WebAssemblyHost> SetLocalStorageLanguage(this WebAssemblyHost app)
    {
        var localStorage = app.Services.GetRequiredService<ILocalStorageService>();

        var currentLang = await localStorage.GetItemAsStringAsync("lang");

        if (currentLang is null)
        {
            currentLang = "fr";
            await localStorage.SetItemAsStringAsync("lang", "fr");
        }

        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(currentLang);
        CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(currentLang);

        return app;
    }
}