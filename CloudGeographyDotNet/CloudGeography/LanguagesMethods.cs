﻿using AngryMonkey.Cloud.Geography;

namespace AngryMonkey.Cloud;

public partial class CloudGeographyClient
{
	public class LanguagesMethods
	{
		private List<Language>? _languages;
		private CloudGeographyClient Client { get; set; }

		internal LanguagesMethods(CloudGeographyClient client) => Client = client;

		private List<Language> Languages => _languages ??= DeserializeModel<List<Language>>("languages") ?? new List<Language>();

		public List<Language> Get(params string[] languageCodes) => languageCodes.Any() ? Languages.Where(key => languageCodes.Any(l => key.CodeCheck(l))).ToList() : Languages;

		public List<CountryLanguage> GetByCountry(string countryCode) => Client.Countries.Get(countryCode).Languages;

		public Language? Get(string languageCode) => Languages.FirstOrDefault(key => key.CodeCheck(languageCode));
	}
}