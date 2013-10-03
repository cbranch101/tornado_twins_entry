using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	float integrity = 100f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(integrity <= 0f) {
			Debug.Log ("Quitting Mofos");
			Application.LoadLevel ("MainMenuScene");
		}
		
		if(Time.time > 15f) {
			integrity = -10f;
		}
	}
	
	public float getIntegrityPercentage() {
		return integrity > 0 ? integrity / 100f : 0;
	}
	
	public void takeDamage(float damageAmount) {
		integrity -= damageAmount;
	}
	
	
}
