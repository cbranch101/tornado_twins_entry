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

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
       	Debug.Log (agent.actionContext.GetContextItem<float>("current_health"));
	List<GameObject> hidingSpots = agent.actionContext.GetContextItem<List<GameObject>>("hiding_spots");
	GameObject selectedHidingSpot = hidingSpots[Random.Range(0, hidingSpots.Count - 1)];
	agent.actionContext.SetContextItem<GameObject>("hiding_spot", selectedHidingSpot);
	return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}