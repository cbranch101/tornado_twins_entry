using UnityEngine;
using System.Collections;
using FPSControl;
using RAIN.Core;
using System.Collections.Generic;

public class SetTestConditions : MonoBehaviour {

	RAIN.Action.ActionContext actionContext;
	RAINAgent agent;
	List<GameObject> hidingSpots;
	
	// Use this for initialization
	void Start () {
		hidingSpots = new List<GameObject>();
		agent = gameObject.GetComponent<RAINAgent>();
		actionContext = agent.Agent.actionContext;
		setHidingSpots();
		setStartingActionContext();
	}
	
	void setStartingActionContext() {
		actionContext.SetContextItem<float>("current_health", 100f);
		actionContext.SetContextItem<List<GameObject>>("hiding_spots", hidingSpots);
		actionContext.SetContextItem<string>("emotional_state", "scared");
	}
	
	void setHidingSpots() {
		GameObject hidingSpotCollection = GameObject.Find ("HidingSpots");
		// the transform variable can be iterated through
	        foreach(Transform child in hidingSpotCollection.transform) {
	         	// your iterating through transforms, so you need to get the game object before you use it. 
	         	hidingSpots.Add(child.gameObject);
	        };
	}

	
	// Update is called once per frame
	void Update () {
		if(Time.time > 1000f) {
			actionContext.SetContextItem<float>("current_health", -10f);
		}
	}
}
