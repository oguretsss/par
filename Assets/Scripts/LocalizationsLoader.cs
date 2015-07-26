using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class LocalizationsLoader : MonoBehaviour {

//	public delegate void LanguageChangedHandler();
//	public event LanguageChangedHandler LanguageChanged;

	public TextAsset russianXml;
	public TextAsset englishXml;

	// Use this for initialization
	void Awake () {
		if (PlayerPrefs.HasKey("Language")) {
			switch (PlayerPrefs.GetString("Language")) {
			case "Russian":
				LoadRussianLanguage();
				break;
			case "English":
				LoadEnglishLanguage();
				break;
			default:
				LoadEnglishLanguage();
				break;
			}
		} 
		else {
			LoadEnglishLanguage();
		}
	}

	public void LoadEnglishLanguage() {
		Strings.SetLanguage(englishXml.ToString());
		PlayerPrefs.SetString("Language","English");
		//LanguageChanged();
	}
	public void LoadRussianLanguage() {
		Strings.SetLanguage(englishXml.ToString());
		PlayerPrefs.SetString("Language","Russian");
		//LanguageChanged();
	}
}
