using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class MoveToPointOfInterest : RAIN.Action.Action
{
    public MoveToPointOfInterest()
    {
        actionName = "MoveToPointOfInterest";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
		return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
		GameObject pointOfInterest = agent.actionContext.GetContextItem<GameObject>("point_of_interest");
		bool arrivedAtTarget = agent.MoveTo(pointOfInterest.transform.position, deltaTime);
		
		if(arrivedAtTarget) {
			return RAIN.Action.Action.ActionResult.SUCCESS;
		} else {
			return RAIN.Action.Action.ActionResult.FAILURE;
		}
		
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}