using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class WorldMapManager : MonoBehaviour {

	enum Zone { Zone1 = 0, Zone2 = 1, Zone3 = 2, Zone4 = 3 }

	public int columns = 15;
	public int rows = 15;

	GameObject player;
	public GameObject start;
	GameObject startTile;
	public GameObject city1, city2, city3, city4;
	public GameObject lab1, lab2, lab3, lab4;
	public GameObject[] worldMapTilePrefabs;
	
	private GameObject[,] mapObjects;

	private Transform worldHolder;
	private List<Vector3> gridPositions = new List<Vector3>();
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void InitializeList() {
		gridPositions.Clear();
		for (int x = 0; x < columns; x++) {
			for (int y = 0; y < rows; y++) {
				gridPositions.Add(new Vector3(x, y, 0f));
			}
		}
	}

	public void WorldSetup() {
		mapObjects = new GameObject[columns, rows];
		worldHolder = new GameObject("WorldMap").transform;
		Debug.Log("Creating World Map.");
		int startY = Random.Range(0, (int) (rows / 2));
		SetupObjectsOnMap(mapObjects);
		for (int x = 0; x < columns; x++) {
			for (int y = 0; y < rows; y++) {
				if (x == 0 && y == startY) {
					startTile = Instantiate(start, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
					mapObjects[x, y] = startTile;
					Debug.Log("start Tile created at: " + mapObjects[x, y].transform.position.ToString());
				}
				else {
					GameObject toInstantiate = worldMapTilePrefabs[Random.Range(0, worldMapTilePrefabs.Length)];
					GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
					instance.transform.SetParent(worldHolder);
					if (mapObjects[x,y] == null)
						mapObjects[x,y] = instance;
					else continue;
				}
			}
		}

		player = GameObject.FindWithTag("Player");
		player.transform.position = startTile.transform.position;
		OnPlayerArrivedAtNewPosition(startTile.transform.position, 1);
		player.GetComponent<Player>().Investigate += OnPlayerArrivedAtNewPosition;
	}
	
	Vector3 RandomPosition() {
		int randomIndex = Random.Range(0, gridPositions.Count);
		Vector3 randomPosition = gridPositions[randomIndex];
		gridPositions.RemoveAt(randomIndex);
		return randomPosition;
	}
	
	void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum) {
		int objectCount = Random.Range(minimum, maximum);
		for (int i = 0; i < objectCount; i++) {
			Vector3 randomPosition = RandomPosition();
			GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
			Instantiate(tileChoice, randomPosition, Quaternion.identity);
		}
	}
	
	public void SetupWorld() {
		WorldSetup();
		InitializeList();
	}

	public Vector3 StartPosition() {
		return start.transform.position;
	}

	void OnPlayerArrivedAtNewPosition(Vector2 coords, int radius) {
		GameObject discoverTile;
		Debug.Log("Arrived at: " + coords);
		for (int x = (int)coords.x - radius; x <= (int)coords.x + radius; x++) {
			for (int y = (int)coords.y - radius; y <= (int)coords.y + radius; y++) {
				if (x < 0 || y < 0 || x > columns - 1 || y > rows - 1) continue;
				else {
					discoverTile = mapObjects[x, y];
					discoverTile.GetComponent<WorldMapTile>().TellAboutSelf();
				}
			}
		}
		LocationManager.instance.LoadLocation(mapObjects[(int)coords.x, (int)coords.y], coords);
	}

	void SetupObjectsOnMap(GameObject[,] map) {
		PlaceObjectOnMap(city1, Zone.Zone1, "City");
		PlaceObjectOnMap(city2, Zone.Zone2, "City");
		PlaceObjectOnMap(city3, Zone.Zone3, "City");
		PlaceObjectOnMap(city4, Zone.Zone4, "City");
		PlaceObjectOnMap(lab1, Zone.Zone1, "Lab");
		PlaceObjectOnMap(lab2, Zone.Zone2, "Lab");
		PlaceObjectOnMap(lab3, Zone.Zone3, "Lab");
		PlaceObjectOnMap(lab4, Zone.Zone4, "Lab");
	}

	void PlaceObjectOnMap(GameObject mapObject, Zone zone, string objType) {
		int x;
		int y;
		switch (zone) {
			case Zone.Zone1:
				x = Random.Range(2, columns / 2);
				y = Random.Range(2, rows / 2);
				if (mapObjects[x,y] != null)
					PlaceObjectOnMap(mapObject, zone, objType);
				else {
					mapObjects[x,y] = Instantiate(mapObject, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
					mapObjects[x,y].transform.SetParent(worldHolder);
					LocationManager.instance.registerNewLocation(new Vector2(x, y), 0, objType);
				}
				break;
			case Zone.Zone2:
				x = Random.Range(0, columns / 2);
				y = Random.Range(rows / 2 + 1, rows - 1);
				if (mapObjects[x,y] != null)
					PlaceObjectOnMap(mapObject, zone, objType);
				else {
					mapObjects[x,y] = Instantiate(mapObject, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
					mapObjects[x,y].transform.SetParent(worldHolder);
					LocationManager.instance.registerNewLocation(new Vector2(x, y), 1, objType);
				}
				break;
			case Zone.Zone3:
				x = Random.Range(columns / 2 + 1, columns - 1);
				y = Random.Range(0, rows / 2);
				if (mapObjects[x,y] != null)
					PlaceObjectOnMap(mapObject, zone, objType);
				else {
					mapObjects[x,y] = Instantiate(mapObject, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
					mapObjects[x,y].transform.SetParent(worldHolder);
					LocationManager.instance.registerNewLocation(new Vector2(x, y), 2, objType);
				}
				break;
			case Zone.Zone4:
				x = Random.Range(columns / 2 + 1, columns - 1);
				y = Random.Range(rows / 2 + 1, rows - 1);
				if (mapObjects[x,y] != null)
					PlaceObjectOnMap(mapObject, zone, objType);
				else {
					mapObjects[x,y] = Instantiate(mapObject, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
					mapObjects[x,y].transform.SetParent(worldHolder);
					LocationManager.instance.registerNewLocation(new Vector2(x, y), 3, objType);
				}
				break;
			default:
				break;
		}
	}

	void AttemptRandomEncounter() {
		Debug.Log("Here you'll meet random encounter... or not...");
	}


}
