using System.Collections;
using UnityEngine;
using Vuforia;

public class VirtualButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler {
	[SerializeField] private VirtualButtonBehaviour[] buttons;
	[SerializeField] private GameObject[] objectList;

    void Start() {
		for (int i = 0; i < this.buttons.Length; i++) {
			this.buttons [i].RegisterEventHandler (this);
		}
    }

	private void Toggle(int index) {
		for (int i = 0; i < this.objectList.Length; i++) {
			this.objectList [i].SetActive (false);
		}

		this.objectList [index].SetActive (true);
	}

    public void OnButtonPressed(VirtualButtonBehaviour vb) {
		for (int i = 0; i < this.buttons.Length; i++) {
			if (vb.name == this.buttons [i].name)
				this.Toggle (i);
		}
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) {

    }
}
