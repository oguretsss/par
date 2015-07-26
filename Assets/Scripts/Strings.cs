using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;

namespace Assets.Scripts {
	public static class Strings {

		static XmlTextReader reader;
		static StringReader stringReader;

		//STRINGS
		public static string YES;
		public static string NO;
		public static string CONTRACTS;
		public static string SHOP;
		public static string EXIT;
		public static string REST;
		public static string ENTER_LOCATION_DIALOG;
		public static string CITY;
		public static string LAB;
		public static string CITY_1_NAME;
		public static string CITY_1_DESCRIPTION;



		public static void SetLanguage(string loadedLanguageAsset) {
			stringReader = new StringReader(loadedLanguageAsset);
			reader = new XmlTextReader(stringReader);

			reader.ReadToFollowing("YES");
			YES = reader.ReadElementContentAsString();
			Debug.Log(YES);

			reader.ReadToFollowing("NO");
			NO = reader.ReadElementContentAsString();
			Debug.Log(NO);

			reader.ReadToFollowing("CONTRACTS");
			CONTRACTS = reader.ReadElementContentAsString();
			Debug.Log(CONTRACTS);

			reader.ReadToFollowing("SHOP");
			SHOP = reader.ReadElementContentAsString();
			Debug.Log(SHOP);

			reader.ReadToFollowing("EXIT");
			EXIT = reader.ReadElementContentAsString();
			Debug.Log(EXIT);

			reader.ReadToFollowing("REST");
			REST = reader.ReadElementContentAsString();
			Debug.Log(REST);

			reader.ReadToFollowing("ENTER_LOCATION_DIALOG");
			ENTER_LOCATION_DIALOG = reader.ReadElementContentAsString();
			Debug.Log(ENTER_LOCATION_DIALOG);

			reader.ReadToFollowing("CITY");
			CITY = reader.ReadElementContentAsString();
			Debug.Log(CITY);

			reader.ReadToFollowing("LAB");
			LAB = reader.ReadElementContentAsString();
			Debug.Log(LAB);

			reader.ReadToFollowing("CITY_1_NAME");
			CITY_1_NAME = reader.ReadElementContentAsString();
			Debug.Log(CITY_1_NAME);

			reader.ReadToFollowing("CITY_1_DESCRIPTION");
			CITY_1_DESCRIPTION = reader.ReadElementContentAsString();
			Debug.Log(CITY_1_DESCRIPTION);

			stringReader.Dispose();
		}
	}
}
