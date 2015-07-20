using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	[HideInInspector]public WorldMapManager worldMapScript;
	CityManager cityManager;
	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
		DontDestroyOnLoad(gameObject);
		worldMapScript = GetComponent<WorldMapManager>();
	}

	void Start() {
		InitGame();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitGame() {
		worldMapScript.WorldSetup();
	}
}
