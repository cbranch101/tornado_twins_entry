using UnityEngine;
using System.Collections;

public class TallBoilerSystem : ShipSystem {

	public ParticleSystem[] steamEffects;
	
	protected override void triggerPowerDownEffects() {
		foreach(ParticleSystem steamEffect in steamEffects) {
			steamEffect.Play();
		}
	} 

}
