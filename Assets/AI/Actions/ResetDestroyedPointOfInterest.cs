using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class ResetDestroyedPointOfInterest : RAIN.Action.Action
{
    public ResetDestroyedPointOfInterest()
    {
        actionName = "ResetDestroyedPointOfInterest";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
		return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
        GameObject pointOfInterest = agent.actionContext.GetContextItem<GameObject>("point_of_interest");
		if(pointOfInterest == null) {
			agent.actionContext.SetContextItem<bool>("point_of_interest_found", false);
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