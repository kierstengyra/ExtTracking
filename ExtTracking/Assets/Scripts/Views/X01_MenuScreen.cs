using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X01_MenuScreen : View {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DisplayTestDialog() {
		DialogInterface dialog = DialogBuilder.Create (DialogBuilder.DialogType.NOTIFICATION);
		dialog.SetMessage ("Test");
		dialog.SetOnDismissListener (() => {
			DialogInterface addedDialog = DialogBuilder.Create(DialogBuilder.DialogType.NOTIFICATION);
			addedDialog.SetMessage("Another test");
		});
	}

	public void LoadARPhysics() {
		LoadManager.Instance.LoadScene (SceneNames.AR_PHYSICS);
	}

	public void LoadExtendedTracking() {
		LoadManager.Instance.LoadScene (SceneNames.EXT_TRACKING);
	}
}
