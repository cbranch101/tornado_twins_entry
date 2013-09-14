using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class SetLookDirection : RAIN.Action.Action
{
    public SetLookDirection()
    {
        actionName = "SetLookDirection";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
        int randomValue = Random.Range(0, 1);
		bool shouldTurnRight = randomValue == 1;
		agent.actionContext.SetContextItem<bool>("should_turn_right", shouldTurnRight);
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