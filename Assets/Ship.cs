using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	float integrity = 100f;
	AudioSource audioSource;
	
	// Use this for initialization
	void Start () {
		audioSource = (AudioSource) gameObject.GetComponent("AudioSource");
	}
	
	// Update is called once per frame
	void Update () {
		if(integrity <= 0f) {
			Debug.Log ("You lose, sucka!");
			Application.LoadLevel ("MainMenuScene");
		}
		
	}
	
	public float getIntegrityPercentage() {
		return integrity > 0 ? integrity / 100f : 0;
	}
	
	public void takeDamage(float damageAmount) {
		integrity -= damageAmount;
	}
	
	public void playNotification(AudioClip notificationClip) {
		Debug.Log ("getting called");
		audioSource.clip = notificationClip;
		audioSource.Play ();
	}
	
	
}
