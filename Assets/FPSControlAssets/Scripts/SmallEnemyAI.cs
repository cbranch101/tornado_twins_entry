using UnityEngine;
using System.Collections;
using FPSControl;
using RAIN.Core;
using System.Collections.Generic;


public class SmallEnemyAI : EnemyAI {
	
	// handle most interactions with the AI
	List<GameObject> hidingSpots;
	
	void setHidingSpots() {
		hidingSpots = new List<GameObject>();
		GameObject hidingSpotCollection = GameObject.Find ("HidingSpots");
		
		// the transform variable can be iterated through
	        foreach(Transform child in hidingSpotCollection.transform) {
	         	
			// your iterating through transforms, so you need to get the game object before you use it. 
	         	hidingSpots.Add(child.gameObject);
			
	        };
		
	}
	
	protected override void setStartingActionContext() {
		setHidingSpots();
		actionContext.SetContextItem<List<GameObject>>("hiding_spots", hidingSpots);
		
	}
	
	protected override void OnAIUpdate() {
		
	}
	
	protected override void OnTakeDamage(float currentHealth, float damageAmount) {
		
	}
	
	
	
}
