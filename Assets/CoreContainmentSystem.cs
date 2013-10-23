using UnityEngine;
using System.Collections;

public class CoreContainmentSystem : ShipSystem {
	
	PlayerHUD playerHUD;
	public ParticleSystem explosionEffect;
	
	protected override void onStart() {
		GameObject playerHudObject = GameObject.Find ("PlayerHUD");
		playerHUD = (PlayerHUD) playerHudObject.GetComponent("PlayerHUD");
	}
	
	protected override void triggerPowerDownEffects() {
		StartCoroutine(handleEndOfGame());
		
	}
	
	public IEnumerator handleEndOfGame() {
		
		explosionEffect.Play ();
		yield return new WaitForSeconds(3);
		playerHUD.gameStatus = "The whole ship blew up underneath you";
		playerHUD.endGame();

		
	}
	
	
}
