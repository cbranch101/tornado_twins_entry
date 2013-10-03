using UnityEngine;
using System.Collections;

public class PlayerHUD : MonoBehaviour {

	public Texture shipIntegrityTexture;
	float shipIntegrityBarWidth = 100f;
	public float maxIntegrityBarWidth = 100f;
	public float shipIntegrityBarHeight = 100f;
	public float shipIntegrity = 100f;
	Ship shipComponent;
	
	// Use this for initialization
	void Start () {
		GameObject shipObject = GameObject.Find ("Ship");
		shipComponent = (Ship) shipObject.GetComponent("Ship");
	}
	
	// Update is called once per frame
	void Update () {
		setIntegrityBarWidth();
	}
	
	void OnGUI() {
		GUI.Label (new Rect(10, 0, 200, 25), "Ship Integrity");
		GUI.DrawTexture(new Rect(10, 25, shipIntegrityBarWidth, shipIntegrityBarHeight), shipIntegrityTexture);
	}
	
	void setIntegrityBarWidth() {
		float currentIntegrityPercentage = shipComponent.getIntegrityPercentage();
		shipIntegrityBarWidth = maxIntegrityBarWidth * currentIntegrityPercentage;
	}
	
	
	
}
