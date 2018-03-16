using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlacerTarget : ImageTargetBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void OnTrackerUpdate(Status newStatus) {
		base.OnTrackerUpdate (newStatus);

		if (newStatus == Status.TRACKED) {
			EventBroadcaster.Instance.PostEvent (EventNames.X01_ExtTracking.ON_OBJPLACER_SCAN);
		}

		if (newStatus == Status.NOT_FOUND) {
			EventBroadcaster.Instance.PostEvent (EventNames.X01_ExtTracking.ON_OBJPLACER_LOST);
		}
	}
}
