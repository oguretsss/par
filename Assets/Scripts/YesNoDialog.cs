using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class YesNoDialog : MonoBehaviour {

	Text dialogMessage;
	// Use this for initialization
	void Start () {
		dialogMessage = GameObject.Find("DialogMessage").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowMessage(string msg) {
		dialogMessage.text = msg;
	}
}
