using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace BackendChallenge.Localization
{
    public static class BackendChallengeLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(BackendChallengeConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(BackendChallengeLocalizationConfigurer).GetAssembly(),
                        "BackendChallenge.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
