using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ObjectPlacer : MonoBehaviour {

	[SerializeField] private Camera arCamera;
	private List<GameObject> placedObjects = new List<GameObject> ();

	// Use this for initialization
	void Start () {
		EventBroadcaster.Instance.AddObserver (EventNames.X01_ExtTracking.ON_SHOW_ALL, this.OnShowAllObjects);
		EventBroadcaster.Instance.AddObserver (EventNames.X01_ExtTracking.ON_HIDE_ALL, this.OnHideAllObjects);
		EventBroadcaster.Instance.AddObserver (EventNames.X01_ExtTracking.ON_DELETE_ALL, this.OnDeleteAll);
	}

	void OnDestroy() {
		EventBroadcaster.Instance.RemoveObserver (EventNames.X01_ExtTracking.ON_SHOW_ALL);
		EventBroadcaster.Instance.RemoveObserver (EventNames.X01_ExtTracking.ON_HIDE_ALL);
		EventBroadcaster.Instance.RemoveObserver (EventNames.X01_ExtTracking.ON_DELETE_ALL);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = this.arCamera.ScreenPointToRay (Input.mousePosition);

			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				Vector3 hitPos = hit.point;

				GameObject template = ObjectManager.Instance.GetSelected ();
				GameObject spawnObject = GameObject.Instantiate (template, this.transform);
				spawnObject.transform.position = hitPos;
				spawnObject.SetActive (true);

				this.placedObjects.Add (spawnObject);
			}
		}
	}

	public void OnHideAllObjects() {
		for (int i = 0; i < this.placedObjects.Count; i++) {
			this.placedObjects [i].SetActive (false);
		}
	}

	public void OnShowAllObjects() {
		for (int i = 0; i < this.placedObjects.Count; i++) {
			this.placedObjects [i].SetActive (true);
		}
	}

	public void OnDeleteAll() {
		for (int i = 0; i < this.placedObjects.Count; i++) {
			GameObject.Destroy (this.placedObjects [i]);
		}
	}
}
