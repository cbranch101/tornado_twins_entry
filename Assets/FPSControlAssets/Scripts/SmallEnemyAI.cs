using UnityEngine;
using System.Collections;
using FPSControl;
using RAIN.Core;
using System.Collections.Generic;


public class SmallEnemyAI : EnemyAI {
	
	// handle most interactions with the AI
	
	List<GameObject> objectsToDestroy;
	public float powerNodeDamage = 10;
	
	
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
