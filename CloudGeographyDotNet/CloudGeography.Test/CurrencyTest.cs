﻿using AngryMonkey.Cloud.Geography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudGeography.Test
{
    [TestClass]
    public class CurrencyTest
    {
        [TestMethod]
        public void Get_All_Currency()
        {
            CloudGeographyClient client = new();
            List<Currency> Currencies = client.Currencies.GetAll();
            Assert.IsTrue(Currencies.Any());
        }
        [TestMethod]
        public void Get_Currencies_From_Currency_Codes()
        {
            CloudGeographyClient client = new();
            List<Currency> Currencies = client.Currencies.Get(new[] { "USD", "LBP" });

            Assert.IsTrue(Currencies.Count == 2);

			Assert.AreEqual("US Dollars", Currencies.First(key => key.Code.Equals("USD", StringComparison.OrdinalIgnoreCase)).NativeName);
			Assert.AreEqual("Lebanese pound", Currencies.First(key => key.Code.Equals("LBP", StringComparison.OrdinalIgnoreCase)).Name);
		}

		[TestMethod]
		public void Get_Currencies_By_CurrencyCode_Cases()
		{
			CloudGeographyClient client = new();
			List<Currency> Currencies = client.Currencies.Get(new[] { "Usd", "lbP" });

			Assert.IsTrue(Currencies.Count == 2);

			Assert.AreEqual("US Dollars", Currencies.First(key => key.Code.Equals("USD", StringComparison.OrdinalIgnoreCase)).NativeName);
			Assert.AreEqual("Lebanese pound", Currencies.First(key => key.Code.Equals("LBP", StringComparison.OrdinalIgnoreCase)).Name);
		}

		[TestMethod]
        public void Get_Country_Currencies_By_Country_Code()
        {
            CloudGeographyClient client = new();
            List<CountryCurrency> Currencies = client.Currencies.GetByCountry("US");
            Assert.IsTrue(Currencies.Any());
        }
        [TestMethod]
        public void Get_Currency_From_Currency_Code()
        {
            CloudGeographyClient client = new();
            Currency Currency = client.Currencies.Get("USD");
            Assert.AreEqual("US Dollars", Currency?.NativeName);
        }

    }
}
