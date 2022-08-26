﻿using System.Diagnostics.Metrics;
using System.Reflection;
using Newtonsoft.Json;

namespace AngryMonkey.Cloud;

public partial class CloudGeographyClient
{
	public CountriesMethods Countries { get; set; }
	public LanguagesMethods Languages { get; set; }
	public CurrenciesMethods Currencies { get; set; }
	public SubdivisionsMethods Subdivisions { get; set; }

	public CloudGeographyClient()
	{
		Countries = new CountriesMethods(this);
		Languages = new LanguagesMethods(this);
		Currencies = new CurrenciesMethods(this);
		Subdivisions = new SubdivisionsMethods(this);
	}

	internal static T? DeserializeModel<T>(string fileName, string directory = "")
	{
		string fullFileName = $"Data{(!string.IsNullOrEmpty(directory) ? $"\\{directory}" : null)}\\{fileName}.json";

		string fullPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fullFileName));

		return JsonConvert.DeserializeObject<T>(File.ReadAllText(fullPath));
	}
}