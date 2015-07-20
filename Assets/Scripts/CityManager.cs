using UnityEngine;
using System.Collections;

public class CityManager : MonoBehaviour {
	
	MapObject[] labs;
	MapObject[] cities;
	MapObject currentLocation;
	public static CityManager instance = null;
	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
		cities = new MapObject[4];
		labs = new MapObject[4];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadCity(Vector2 coords) {
		for (int i = 0; i < cities.Length; i++) {
			if (coords == cities[i].Location)
				currentLocation = cities[i];
		}
		Debug.Log("Current Location is: " + currentLocation.Type + currentLocation.mapObjectNumber);
		//Application.LoadLevel(currentLocation.Type);
	}

	public void LoadLab(Vector2 coords) {
		for (int i = 0; i < labs.Length; i++) {
			if (coords == labs[i].Location)
				currentLocation = labs[i];
		}
		Debug.Log("Current Location is: " + currentLocation.Type + currentLocation.mapObjectNumber);
	}

	public void registerNewLocation(Vector2 coords, int number, string objType) {
		switch (objType) {
		case "City":
			if (cities[number] == null)
				cities[number] = new MapObject(coords, number, objType);
			break;
		case "Lab":
			if (labs[number] == null)
				labs[number] = new MapObject(coords, number, objType);
			break;
		}
	}

	class MapObject {
		public Vector2 Location { get; set; }
		public int mapObjectNumber;
		public string Type { get; set; }

		public MapObject() {
			Location = new Vector2();
			mapObjectNumber = 0;
			Type = "empty";
		}
		public MapObject (Vector2 coords, int number, string objType) {
			Location = coords;
			mapObjectNumber = number;
			Type = objType;
		}

	}
}
