using UnityEngine;
using System.Collections;

public class WorldMapTile : MonoBehaviour {

	[HideInInspector] public Vector2 coordinates;
	public Sprite hiddenSprite;
	Sprite originalSprite;
	// Use this for initialization
	void Awake () {
		coordinates = (Vector2)transform.position;
		originalSprite = GetComponent<SpriteRenderer>().sprite;
		GetComponent<SpriteRenderer>().sprite = hiddenSprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TellAboutSelf() {
		GetComponent<SpriteRenderer>().sprite = originalSprite;
	}
}
