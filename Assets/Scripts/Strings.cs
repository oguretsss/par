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
		public static string ENTER_LOCATION_DIALOG;
		public static string CITY;
		public static string LAB;



		public static void SetLanguage(string loadedLanguageAsset) {
			stringReader = new StringReader(loadedLanguageAsset);
			reader = new XmlTextReader(stringReader);
			reader.ReadToFollowing("YES");
			YES = reader.ReadElementContentAsString();
			Debug.Log(YES);

			reader.ReadToFollowing("NO");
			NO = reader.ReadElementContentAsString();
			Debug.Log(NO);

			reader.ReadToFollowing("ENTER_LOCATION_DIALOG");
			ENTER_LOCATION_DIALOG = reader.ReadElementContentAsString();
			Debug.Log(ENTER_LOCATION_DIALOG);

			reader.ReadToFollowing("CITY");
			CITY = reader.ReadElementContentAsString();
			Debug.Log(CITY);

			reader.ReadToFollowing("LAB");
			LAB = reader.ReadElementContentAsString();
			Debug.Log(LAB);
			stringReader.Dispose();
		}
	}
}
