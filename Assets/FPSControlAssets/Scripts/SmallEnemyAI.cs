using UnityEngine;
using System.Collections;
using FPSControl;
using RAIN.Core;
using System.Collections.Generic;


public class SmallEnemyAI : EnemyAI {
	
	// handle most interactions with the AI
	
	List<EnemySpawner> spawnPoints = new List<EnemySpawner>();
	
	public float powerNodeDamage = 10;
		
	protected void setSpawnPoints() {
		GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("Respawn");
		foreach(GameObject spawnPointObject in spawnPointObjects) {
			EnemySpawner spawner = (EnemySpawner)spawnPointObject.GetComponent("EnemySpawner");
			spawnPoints.Add (spawner);
		}
	}
	
	protected void setObjectsToDestroy() {
		List<GameObject> objectsToDestroy = new List<GameObject>();
		GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("Destroyable");
		foreach(GameObject foundObject in foundObjects) {
			objectsToDestroy.Add (foundObject);
		}

		actionContext.SetContextItem<List<GameObject>>("objects_to_destroy", objectsToDestroy);
	}
	
	
	protected override void setStartingActionContext() {
		setSpawnPoints();
		setObjectsToDestroy();
		actionContext.SetContextItem<SmallEnemyAI>("ai_component", this);
		
	}
	
	public void spawnSpiderAtRandomSpawnPoint() {
		EnemySpawner selectedSpawner = spawnPoints[Random.Range (0, spawnPoints.Count - 1)];
		selectedSpawner.spawnSpider();
	}
	
	protected override void OnAIUpdate() {

	}	
	
	
	
}
