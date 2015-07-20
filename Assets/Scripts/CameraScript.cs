using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	GameObject player;
	Vector3 pos;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		pos = player.transform.position;
		pos.z = -10;
		transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
		FollowPlayer();
	}

	void FollowPlayer() {
		pos = player.transform.position;
		pos.z = -10;
		transform.position = pos;
	}
}
