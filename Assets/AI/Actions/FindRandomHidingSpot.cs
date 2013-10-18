using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;
using System.Collections.Generic;

public class FindRandomHidingSpot : RAIN.Action.Action
{
    public FindRandomHidingSpot()
    {
        actionName = "FindRandomHidingSpot";
    }

  	GameObject findHidingSpotToTheSidesOfThePlayer(RAIN.Core.Agent agent) {
		GameObject player = GameObject.Find("PlayerConfigured");
		List<GameObject> hidingSpots = agent.actionContext.GetContextItem<List<GameObject>>("hiding_spots");
		GameObject bestHidingSpot = null;
		float lowestRating = 500f;
		foreach(GameObject hidingSpot in hidingSpots) {
			Vector3 hidingSpotDirection = agent.Avatar.gameObject.transform.position - hidingSpot.transform.position;
			float angleBetweenHidingSpotAndPlayer = Vector3.Angle(hidingSpotDirection, player.transform.forward * -1);
			float angleRating = Mathf.Abs(angleBetweenHidingSpotAndPlayer - 90);
			if(angleRating < lowestRating) {
				lowestRating = angleRating;
				bestHidingSpot = hidingSpot;
			}
		}
		return bestHidingSpot;
		
	}
	
	public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
	
	
	
	return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
	GameObject selectedHidingSpot = findHidingSpotToTheSidesOfThePlayer(agent);
		agent.actionContext.SetContextItem<GameObject>("move_target", selectedHidingSpot);
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}