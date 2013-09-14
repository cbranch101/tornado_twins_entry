using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Path;
using RAIN.Action;

public class SimpleMove : RAIN.Action.Action
{
    public SimpleMove()
    {
        actionName = "SimpleMove";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
		bool canMove = agent.actionContext.GetContextItem<bool>("can_move");
		MoveLookTarget moveTarget = new MoveLookTarget();
		if(canMove) {
			GameObject pointOfInterest = agent.actionContext.GetContextItem<GameObject>("point_of_interest");
			moveTarget.TransformTarget = pointOfInterest.transform;
			agent.MoveTarget = moveTarget;
			agent.Move(deltaTime);
			return RAIN.Action.Action.ActionResult.SUCCESS;
		} else {
			moveTarget.TransformTarget = agent.Avatar.gameObject.transform;
			Debug.Log ("firing");
			agent.MoveTarget = moveTarget;
			return RAIN.Action.Action.ActionResult.FAILURE;
		}
		
        
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}