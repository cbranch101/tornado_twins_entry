using UnityEngine;
using System.Collections;
using FPSControl;
using System;
using System.Reflection;

public class PlayerHUD : MonoBehaviour {

	public Texture barTexture;
	public float barHeight = 100f;
	public float barWidth = 100f;
	Ship shipComponent;
	float barXPosition;
	DataController dataController;
	public float distanceFromBottom = 30;
	public string currentMessage;
	private bool gameOver = false;
	int startTime;
	int restSeconds;
	int roundedRestSeconds;
	int displaySeconds;
	int displayMinutes;
	int countdownSeconds = 120;
	public string gameStatus;
	
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
	
	void Awake () {
		startTime = (int) Time.time;
	}
	
	public void PlayerDied() {
		Debug.Log ("getting called");
	}
	
	public void endGame() {
		gameOver = true;
	}
	
	
	
	void OnGUI() {
		if(!gameOver) {
			drawInGameHud();
		} else {
			drawGameOver();
		}
		
	}
	
	void drawGameOver() {
		GameObject player = GameObject.Find ("PlayerConfigured");
		GameObject.Destroy(player);
		GUI.Label (new Rect(0, 0, 300, 25), gameStatus);
		if (GUI.Button(new Rect(10, 70, 50, 30), "Restart")) {
			Application.LoadLevel("MainHanger_WithNodes_Clay");
		}
		
	}
	
	void drawInGameHud() {
		int guiTime = (int) Time.time - startTime;
		
		restSeconds = countdownSeconds - guiTime;
		
		if(restSeconds == 0) {
			gameStatus = "You survived, somehow";
			endGame();
		}
		
		roundedRestSeconds = Mathf.CeilToInt(restSeconds);
		displaySeconds = roundedRestSeconds % 60;
		displayMinutes = roundedRestSeconds / 60;
		
		string text = String.Format("{0:00}:{1:00}", displayMinutes, displaySeconds);
		
		GUI.Label (new Rect(0, 0, 300, 25), "Survive for : " + text);
		float currentShipIntegrity = getShipIntegrity();
		float currentHealth = getHealth();
		GUI.Label (new Rect(10, barXPosition - 15, 200, 25), "Health");
		GUI.DrawTexture(new Rect(10, barXPosition, currentHealth, barHeight), barTexture);
		
	}
	
	float getHealth() {
		if(dataController.current > 0f) {
			float currentHealthPercentage = dataController.current / dataController.max;
			return barWidth * currentHealthPercentage;
		} else {
			gameStatus = "You died of spider, game over";
			endGame ();
			return 0;
		}
		
	}
	
	float getShipIntegrity() {
		float currentIntegrityPercentage = shipComponent.getIntegrityPercentage();
		return barWidth * currentIntegrityPercentage;
	}
		
	
	
}
