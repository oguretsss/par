using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class LocationManager : MonoBehaviour {

	public delegate void LocationHandler(GameObject obj, Vector2 coordinates, string header);
	public event LocationHandler EnterLocation;
	MapObject[] labs;
	MapObject[] cities;
	MapObject currentLocation;
	public static LocationManager instance = null;
	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
		cities = new MapObject[4];
		labs = new MapObject[4];
	}

	public void LoadLocation(GameObject tile, Vector2 coordinates) {
		switch (tile.transform.tag) {
		case "City":
			LoadCity(coordinates);
			EnterLocation(tile, coordinates, Strings.CITY);
			break;
		case "Lab":
			LoadLab(coordinates);
			EnterLocation(tile, coordinates, Strings.LAB);
			break;
		default:
			Debug.Log("Хуйня какая-то получилась!");
			break;
		}
	}
	void LoadCity(Vector2 coords) {
		for (int i = 0; i < cities.Length; i++) {
			if (coords == cities[i].Location)
				currentLocation = cities[i];
		}
		Debug.Log("Current Location is: " + currentLocation.Type + currentLocation.mapObjectNumber);
	}

	void LoadLab(Vector2 coords) {
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

	public void ChangeScene() {
			switch (currentLocation.Type) {
				case "City":
					Debug.Log("Loading city from ChangeScene()...");
					break;
				case "Lab":
					Debug.Log("Loading lab from ChangeScene()...");
					break;
				default:
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
