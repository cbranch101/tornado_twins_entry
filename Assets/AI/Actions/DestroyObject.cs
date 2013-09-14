using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class DestroyObject : RAIN.Action.Action
{
    public DestroyObject()
    {
        actionName = "DestroyObject";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
       	GameObject pointOfInterest = agent.actionContext.GetContextItem<GameObject>("point_of_interest");
		GameObject.Destroy(pointOfInterest);
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