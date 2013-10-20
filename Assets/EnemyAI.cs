using UnityEngine;
using System.Collections;
using FPSControl;
using RAIN.Core;
using System.Collections.Generic;


public class EnemyAI : MonoBehaviour {

	public string startingEmotionalState = "none";
	// manages health
	protected DataController healthController;
	protected RAINAgent agent;
	protected RAIN.Action.ActionContext actionContext;
	protected List<GameObject> hidingSpots;
	protected GameObject player;

	
	// Use this for initialization
	void Start () {
		
		setRainObjects();
		setBaseActionContext();
		setStartingActionContext();
		
	}
	
	protected void setHidingSpots() {
		hidingSpots = new List<GameObject>();
		GameObject hidingSpotCollection = GameObject.Find ("HidingSpots");
		
		// the transform variable can be iterated through
	        foreach(Transform child in hidingSpotCollection.transform) {
	         	
			// your iterating through transforms, so you need to get the game object before you use it. 
	         	hidingSpots.Add(child.gameObject);
			
	        };
		actionContext.SetContextItem<List<GameObject>>("hiding_spots", hidingSpots);
		
	}
	
	// Update is called once per frame
	void Update () {
		actionContext.SetContextItem<float>("current_health", getCurrentHealth());
		OnAIUpdate();
	}
	
	protected virtual void OnAIUpdate() {
		
	}
	
	void ApplyDamage(DamageSource damageSource) {
		if (ifDamageIsGunShot(damageSource)) {
			takeDamage(damageSource.damageAmount);
		}
	}
	
	bool ifDamageIsGunShot(DamageSource damageSource) {
		return (damageSource.sourceType == DamageSource.DamageSourceType.GunFire) &&
		    (damageSource.sourceObjectType != DamageSource.DamageSourceObjectType.Obstacle); 
		
	} 
	
	void takeDamage(float damageAmount) {
		healthController.current -= damageAmount;
		OnTakeDamage(healthController.current, damageAmount);
	}
	
	protected virtual void OnTakeDamage(float currentHealth, float damageAmount) {
		
	}

	
	protected virtual void setStartingActionContext() {

	}
	
	void setRainObjects() {
		agent = gameObject.GetComponent<RAINAgent>();
		healthController = gameObject.GetComponent<DataController>();
		actionContext = agent.Agent.actionContext;
	}
	
	void setBaseActionContext() {
		actionContext.SetContextItem<bool>("is_dead", false);
		actionContext.SetContextItem<string>("emotional_state", startingEmotionalState);
		actionContext.SetContextItem<float>("current_health", getCurrentHealth());
		setHidingSpots();
		setPlayer ();
	}
	
	protected void setPlayer() {
		player = GameObject.Find ("PlayerConfigured");
		actionContext.SetContextItem<GameObject>("player", player);
	}
	
	protected float getCurrentHealth() {
		return healthController.current;		
	}
	
	

	
}
