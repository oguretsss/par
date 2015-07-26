using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class WorldMapCanvas : MonoBehaviour {

	GameObject yesNoDialogBox, yesNoDialogMessage, btnYes, btnNo, dialogHeader;
	// Use this for initialization
	void Awake () {
		yesNoDialogBox = GameObject.Find("YesNoDialogBox");
		yesNoDialogMessage = GameObject.Find("DialogMessage");
		btnNo = GameObject.Find ("BtnNo");
		btnYes = GameObject.Find ("BtnYes");
		dialogHeader = GameObject.Find ("DialogHeader");
		ReloadUI();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void ReloadUI() {
		yesNoDialogBox.SetActive(false);
	}

	public void ShowYesNoDialog(UnityAction yesMethod, string msg, string header) {
		btnYes.GetComponent<Button>().onClick.AddListener(yesMethod);
		yesNoDialogMessage.GetComponent<Text>().text = msg;
		dialogHeader.GetComponent<Text>().text = header;
		yesNoDialogBox.SetActive(true);
	}

	public void HideYesNoDialog() {
		yesNoDialogBox.SetActive(false);
	}
}
