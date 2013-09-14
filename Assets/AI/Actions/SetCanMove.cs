using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class SetCanMove : RAIN.Action.Action
{
    public SetCanMove()
    {
        actionName = "SetCanMove";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
		agent.actionContext.SetContextItem<bool>("can_move", true);
		return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
		if(Time.time > 2f) {
			agent.actionContext.SetContextItem<bool>("can_move", false);
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