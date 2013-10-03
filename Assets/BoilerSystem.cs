using UnityEngine;
using System.Collections;

public class BoilerSystem : ShipSystem {
	
	protected override void OnPowerUp ()
	{
		gameObject.renderer.material.color = Color.green;	
	}
	
	protected override void OnPowerDown() {
		shipComponent.takeDamage(integrityAmount);
		gameObject.renderer.material.color = Color.red;
	}
	
}
