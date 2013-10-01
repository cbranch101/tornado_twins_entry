using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class PointOfInterestHasBeenDeleted : RAIN.Action.Action
{
    public PointOfInterestHasBeenDeleted()
    {
        actionName = "PointOfInterestHasBeenDeleted";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
	GameObject pointOfInterest = agent.actionContext.GetContextItem<GameObject>("point_of_interest");
	if(pointOfInterest == null) {
		return RAIN.Action.Action.ActionResult.FAILURE;	
	} else {
		return RAIN.Action.Action.ActionResult.SUCCESS;	 	
	}
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}