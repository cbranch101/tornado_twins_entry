using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class SetPointOfInterest : RAIN.Action.Action
{
    public SetPointOfInterest()
    {
        actionName = "SetPointOfInterest";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
		GameObject moveTarget = GameObject.Find("RunPoint");
		Debug.Log (moveTarget);
		agent.actionContext.SetContextItem<GameObject>("point_of_interest", moveTarget);
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