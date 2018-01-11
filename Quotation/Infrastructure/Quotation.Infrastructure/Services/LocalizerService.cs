﻿using Quotation.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WPFLocalizeExtension.Engine;
using WPFLocalizeExtension.Extensions;

namespace Quotation.Infrastructure.Services
{
    public class LocalizerService : ILocalizerService
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="culture"></param>
        public LocalizerService(string culture)
        {
            this.SupportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures).Where(c => c.IetfLanguageTag.Equals("en-US") ||
                                                                                                   c.IetfLanguageTag.Equals("de-DE"))
                                                                                       .ToList<CultureInfo>();
            this.SetLocale(culture);
        }

        /// <summary>
        /// Set localization
        /// </summary>
        /// <param name="locale"></param>
        public void SetLocale(string locale)
        {
            LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo(locale);
        }

        /// <summary>
        /// Set localization
        /// </summary>
        /// <param name="culture"></param>
        public void SetLocale(CultureInfo culture)
        {
            LocalizeDictionary.Instance.Culture = culture;
        }

        /// <summary>
        /// Get localized string from resource dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetLocalizedString(string key)
        {
            string uiString;
            LocExtension locExtension = new LocExtension(key);
            locExtension.ResolveLocalizedValue(out uiString);
            return uiString;
        }

        /// <summary>
        /// List with supported languages
        /// </summary>
        public IList<CultureInfo> SupportedLanguages { get; private set; }

        /// <summary>
        /// The current selected language
        /// </summary>
        public CultureInfo SelectedLanguage
        {
            get { return LocalizeDictionary.Instance.Culture; }
            set { this.SetLocale(value); }
        }
    }
}