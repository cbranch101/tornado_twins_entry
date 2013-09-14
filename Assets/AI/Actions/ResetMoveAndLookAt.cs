using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class ResetMoveAndLookAt : RAIN.Action.Action
{
    public ResetMoveAndLookAt()
    {
        actionName = "ResetMoveAndLookAt";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
		return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
       Debug.Log ("resetting!");
		agent.MoveTo(agent.Avatar.gameObject.transform.position, 0);
		agent.LookAt(agent.Avatar.gameObject.transform.position, 0);

		return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}