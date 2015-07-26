using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;

public class CityCanvas : MonoBehaviour {

	GameObject btnQuests, btnExit, btnRest, btnShop;
	GameObject cityNameLabel, cityDescription;
	// Use this for initialization
	void Awake () {
		btnQuests = GameObject.Find("BtnQuests");
		btnExit = GameObject.Find("BtnExit");
		btnRest = GameObject.Find("BtnRest");
		btnShop = GameObject.Find("BtnShop");
		cityNameLabel = GameObject.Find("CityName");
		cityDescription = GameObject.Find("CityDescription");

		ReloadCityUI();
	}

	void ReloadCityUI(){
		btnQuests.GetComponentInChildren<Text>().text = Strings.CONTRACTS;
		btnExit.GetComponentInChildren<Text>().text = Strings.EXIT;
		btnRest.GetComponentInChildren<Text>().text = Strings.REST;
		btnShop.GetComponentInChildren<Text>().text = Strings.SHOP;

		cityNameLabel.GetComponent<Text>().text = Strings.CITY_1_NAME;
		cityDescription.GetComponent<Text>().text = Strings.CITY_1_DESCRIPTION;

	}
}
