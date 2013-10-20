using UnityEngine;
using System.Collections;
using FPSControl;

public class PlayerHUD : MonoBehaviour {

	public Texture barTexture;
	public float barHeight = 100f;
	public float barWidth = 100f;
	Ship shipComponent;
	float barXPosition;
	DataController dataController;
	public float distanceFromBottom = 30;
	public string currentMessage;
	
	// Use this for initialization
	void Start () {
		GameObject shipObject = GameObject.Find ("Ship");
		GameObject player = GameObject.Find ("PlayerConfigured");
		dataController = (DataController) player.GetComponent("DataController");
		shipComponent = (Ship) shipObject.GetComponent("Ship");
		barXPosition = Screen.height - distanceFromBottom;
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnGUI() {
		GUI.Label (new Rect(0, 0, 300, 25), currentMessage);
		float currentShipIntegrity = getShipIntegrity();
		float currentHealth = getHealth();
		GUI.Label (new Rect(10, barXPosition - 15, 200, 25), "Health");
		GUI.DrawTexture(new Rect(10, barXPosition, currentHealth, barHeight), barTexture);
		
		GUI.Label (new Rect(10 + barWidth + 30, barXPosition - 15, 200, 25), "Ship Integrity");
		GUI.DrawTexture(new Rect(10 + barWidth + 30, barXPosition, currentShipIntegrity, barHeight), barTexture);
		
	}
	
	float getHealth() {
		if(dataController.current > 0f) {
			float currentHealthPercentage = dataController.current / dataController.max;
			return barWidth * currentHealthPercentage;
		} else {
			return 0;
		}
		
	}
	
	float getShipIntegrity() {
		float currentIntegrityPercentage = shipComponent.getIntegrityPercentage();
		return barWidth * currentIntegrityPercentage;
	}
		
	
	
}
