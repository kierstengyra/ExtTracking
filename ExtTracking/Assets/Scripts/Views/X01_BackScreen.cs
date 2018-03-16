using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X01_BackScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Log ("Escape");
			DisplayExitDialog ();
		}
	}

	public void DisplayExitDialog() {
		Debug.Log ("Display");
		DialogInterface dialog = DialogBuilder.Create (DialogBuilder.DialogType.CHOICE_DIALOG);
		dialog.SetMessage ("Are you sure you want to go back?");
		dialog.SetOnConfirmListener (() => {
			LoadManager.Instance.LoadScene(SceneNames.MAIN_SCENE);
		});
	}
}
