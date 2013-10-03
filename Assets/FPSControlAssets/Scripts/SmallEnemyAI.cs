using UnityEngine;
using System.Collections;
using FPSControl;
using RAIN.Core;
using System.Collections.Generic;


public class SmallEnemyAI : EnemyAI {
	
	// handle most interactions with the AI
	List<GameObject> hidingSpots;
	List<GameObject> objectsToDestroy;
	public float powerNodeDamage = 10;
	
	void setHidingSpots() {
		hidingSpots = new List<GameObject>();
		GameObject hidingSpotCollection = GameObject.Find ("HidingSpots");
		
		// the transform variable can be iterated through
	        foreach(Transform child in hidingSpotCollection.transform) {
	         	
			// your iterating through transforms, so you need to get the game object before you use it. 
	         	hidingSpots.Add(child.gameObject);
			
	        };
		actionContext.SetContextItem<List<GameObject>>("hiding_spots", hidingSpots);
		
	}
	
	void setObjectsToDestroy() {
		objectsToDestroy = new List<GameObject>();
		GameObject[] foundGameObjects = GameObject.FindGameObjectsWithTag("Destroyable");
		foreach(GameObject objectToDestroy in foundGameObjects) {
			objectsToDestroy.Add(objectToDestroy);
		}
		actionContext.SetContextItem<List<GameObject>>("objects_to_destroy", objectsToDestroy);
	}

	
	protected override void setStartingActionContext() {
		setHidingSpots();
		setObjectsToDestroy();
	}
	
	protected override void OnAIUpdate() {
		
	}
	
	protected override void OnTakeDamage(float currentHealth, float damageAmount) {
		
	}
	
	
	
}
