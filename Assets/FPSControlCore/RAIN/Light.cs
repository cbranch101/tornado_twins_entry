using UnityEngine;
using System.Collections;
using FPSControl;
using RAIN.Core;
using RAIN.Path;

public class Light : ShipSystem {

	RAIN.Path.Dynamic.GraphModifier graphModifier;
	// Use this for initialization
	protected override void onStart () {
		failureNotificaiton = "Light " + gameObject.name + " failed";
		graphModifier = (RAIN.Path.Dynamic.GraphModifier) gameObject.GetComponent ("GraphModifier");
		
	}
		
	protected override void triggerPowerDownEffects() {
		Destroy (gameObject);
	}
	
	protected override void triggerPowerUpEffects() {
		
	}

}
