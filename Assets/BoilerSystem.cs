using UnityEngine;
using System.Collections;

public class BoilerSystem : ShipSystem {
	
	protected override void triggerPowerDownEffects() {
		shipComponent.takeDamage(integrityAmount);
		gameObject.renderer.material.color = Color.red;
	}
	
	protected override void triggerPowerUpEffects() {
		gameObject.renderer.material.color = Color.green;
	}
		
}
