using UnityEngine;
using System.Collections;
using FPSControl;
using RAIN.Core;
using System.Collections.Generic;

public class BigEnemyAI : EnemyAI {
	
	List<GameObject> objectsToDestroy;
	
	protected override void setStartingActionContext() {
		
	}
	
	void setObjectsToDestory() {
		objectsToDestroy = new List<GameObject>();
		GameObject[] foundGameObjects = GameObject.FindGameObjectsWithTag("Destroyable");
		foreach(GameObject objectToDestroy in foundGameObjects) {
			objectsToDestroy.Add(objectToDestroy);
		}
		actionContext.SetContextItem<List<GameObject>>("objects_to_destory", objectsToDestroy);
		
	}
	
	protected override void OnAIUpdate() {
		
	}
	
	protected override void OnTakeDamage(float currentHealth, float damageAmount) {
		
	}
	
	
	
}
