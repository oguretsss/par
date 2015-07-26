using UnityEngine;
using UnityEngine.Events;
//using System.Collections;
using System;
using Assets.Scripts;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	[HideInInspector]public WorldMapManager worldMapScript;
	LocalizationsLoader localization;
	Player player; 
	GameObject canvas;
	
	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
		DontDestroyOnLoad(gameObject);
		worldMapScript = GetComponent<WorldMapManager>();
		canvas = GameObject.Find("Canvas");

	}

	void Start() {
		InitGame();
		player = GameObject.FindWithTag("Player").GetComponent<Player>();
		player.GetComponent<Player>().ContinueMoving();
		LocationManager.instance.EnterLocation += new LocationManager.LocationHandler(ProposeEnteringLocation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitGame() {
		worldMapScript.WorldSetup();
	}

	public void PauseGame() {
		player.StopMoving();
	}

	public void ProposeEnteringLocation(GameObject tile, Vector2 coords, string dialogName) {
		PauseGame();
		canvas.GetComponent<WorldMapCanvas>().ShowYesNoDialog(LoadLocation, Strings.ENTER_LOCATION_DIALOG, dialogName);
	}

	void LoadLocation() {
		canvas.GetComponent<WorldMapCanvas>().HideYesNoDialog();
		LocationManager.instance.ChangeScene();
		player.ContinueMoving();
	}

}
