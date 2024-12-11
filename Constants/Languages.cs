using MAUIEden.Models;
using System.Collections.ObjectModel;

namespace MAUIEden.Constants
{
    public static class Languages
    {
        public static ObservableCollection<Language> LanguagesList = new ObservableCollection<Language>
        {
            new Language{Code = "en", Name = "🇬🇧 English"},
            new Language{Code = "es", Name = "🇪🇸 Spanish"},
            new Language{Code = "it", Name = "🇮🇹 Italian"},
            new Language{Code = "de", Name = "🇩🇪 German"},
            new Language{Code = "fr", Name = "🇫🇷 French"},
            new Language{Code = "zh", Name = "🇨🇳 Chinese"}
        };
    }
}