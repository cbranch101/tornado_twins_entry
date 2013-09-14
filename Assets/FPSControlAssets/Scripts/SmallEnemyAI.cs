using UnityEngine;
using System.Collections;
using FPSControl;
using RAIN.Core;
using System.Collections.Generic;


public class SmallEnemyAI : MonoBehaviour {
	
	// handle most interactions with the AI
	RAINAgent agent;
	RAIN.Action.ActionContext actionContext;
	List<GameObject> hidingSpots;
	
	
	// manages health
	DataController healthController;
	
	// Use this for initialization
	void Start () {
		
		hidingSpots = new List<GameObject>();
		agent = gameObject.GetComponent<RAINAgent>();
		healthController = gameObject.GetComponent<DataController>();
		actionContext = agent.Agent.actionContext;
		setStartingActionContext();
		setHidingSpots();
		
	}
	
	void setHidingSpots() {
		
		GameObject hidingSpotCollection = GameObject.Find ("HidingSpots");
		
		// the transform variable can be iterated through
        foreach(Transform child in hidingSpotCollection.transform) {
         	// your iterating through transforms, so you need to get the game object before you use it. 
         	hidingSpots.Add(child.gameObject);
        };
		
	}
	
	void setStartingActionContext() {
		
		// set that the enemy is not dead
		actionContext.SetContextItem<bool>("is_dead", false);
		actionContext.SetContextItem<float>("current_health", getCurrentHealth());
		actionContext.SetContextItem<List<GameObject>>("hiding_spots", hidingSpots);
	}
	
	float getCurrentHealth() {
		
		return healthController.current;		
	}
			
			
	// Update is called once per frame
	void Update () {
		actionContext.SetContextItem<float>("current_health", getCurrentHealth());
	}
	
	void ApplyDamage(DamageSource damageSource) {
		Debug.Log (damageSource);
		if (ifDamageIsGunShot(damageSource)) {
			takeDamage(damageSource.damageAmount);
		}
	}
	
	void takeDamage(float damageAmount) {
		healthController.current -= damageAmount;
	}
	
	bool ifDamageIsGunShot(DamageSource damageSource) {
		return (damageSource.sourceType == DamageSource.DamageSourceType.GunFire) &&
		    (damageSource.sourceObjectType != DamageSource.DamageSourceObjectType.Obstacle); 
		
	}
	
}
