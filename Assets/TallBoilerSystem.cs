using UnityEngine;
using System.Collections;

public class TallBoilerSystem : ShipSystem {

	public ParticleSystem[] steamEffects;
	public AudioClip steamSound;
		
	protected override void triggerPowerDownEffects() {
		foreach(ParticleSystem steamEffect in steamEffects) {
			AudioSource audioSource = (AudioSource) gameObject.GetComponent ("AudioSource");
			audioSource.clip = steamSound;
			audioSource.Play();
			steamEffect.Play(); 
		}
	} 

}
