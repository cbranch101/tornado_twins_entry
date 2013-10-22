using UnityEngine;
using System.Collections;

public class ShipSystem : MonoBehaviour {

	public float integrityAmount;
	protected Ship shipComponent;
	public string failureNotificaiton = "system failed";
	protected PlayerHUD playerHUD;
	
	protected virtual void triggerPowerDownEffects() {
		
	}
	
	protected virtual void triggerPowerUpEffects() {
		
	}
	
	protected void OnPowerUp ()
	{
		

		triggerPowerUpEffects();
	}
	
	protected void OnPowerDown() {
		playerHUD.currentMessage = failureNotificaiton;
		triggerPowerDownEffects();
	}
	
	protected virtual void onStart() {
		
	}
	
	
	// Use this for initialization
	protected void Start () {
		GameObject shipObject = GameObject.Find("Ship");
		shipComponent = (Ship) shipObject.GetComponent("Ship");
		GameObject playerHudObject = GameObject.Find ("PlayerHUD");
		playerHUD = (PlayerHUD) playerHudObject.GetComponent("PlayerHUD");
		onStart ();
	}
	
	// Update is called once per frame
	protected void Update () {
		
	}
}
