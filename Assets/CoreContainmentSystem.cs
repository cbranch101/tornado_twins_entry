using UnityEngine;
using System.Collections;

public class CoreContainmentSystem : ShipSystem {
	
	PlayerHUD playerHUD;
	
	protected override void onStart() {
		GameObject playerHudObject = GameObject.Find ("PlayerHUD");
		playerHUD = (PlayerHUD) playerHudObject.GetComponent("PlayerHUD");
	}
	
	protected override void triggerPowerDownEffects() {
		playerHUD.gameStatus = "The whole ship blew up underneath you";
		playerHUD.endGame();
	}
	
	
}
