using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPlacerUI : MonoBehaviour {

	[SerializeField] private GameObject uiCanvas;

	private bool isHidden = false;

	// Use this for initialization
	void Start () {
		EventBroadcaster.Instance.AddObserver (EventNames.X01_ExtTracking.ON_OBJPLACER_SCAN, this.OnObjPlacerScan);
		EventBroadcaster.Instance.AddObserver (EventNames.X01_ExtTracking.ON_OBJPLACER_LOST, this.OnObjPlacerLost);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy() {
		EventBroadcaster.Instance.RemoveObserver (EventNames.X01_ExtTracking.ON_OBJPLACER_SCAN);
		EventBroadcaster.Instance.RemoveObserver (EventNames.X01_ExtTracking.ON_OBJPLACER_LOST);
	}

	private void OnObjPlacerScan() {
		this.uiCanvas.SetActive (true);
	}

	private void OnObjPlacerLost() {
		this.uiCanvas.SetActive(false);
	}

	public void OnButtonSpawnClicked(int index) {
		ObjectManager.Instance.SetSelected (index);
	}

	public void OnToggleHideClick() {
		if (this.isHidden) {
			this.isHidden = false;
			EventBroadcaster.Instance.PostEvent (EventNames.X01_ExtTracking.ON_SHOW_ALL);
		} else {
			this.isHidden = true;
			EventBroadcaster.Instance.PostEvent (EventNames.X01_ExtTracking.ON_HIDE_ALL);
		}
	}

	public void OnDeleteClick() {
		EventBroadcaster.Instance.PostEvent (EventNames.X01_ExtTracking.ON_DELETE_ALL);
	}
}
