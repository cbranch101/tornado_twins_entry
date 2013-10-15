using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class SelectRandomDeadRat : RAIN.Action.Action
{
    public SelectRandomDeadRat()
    {
        actionName = "SelectRandomDeadRat";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
	List<GameObject> deadRats = agent.actionContext.GetContextItem<List<GameObject>>("dead_rats");
	GameObject selectedDeadRat = deadRats[Random.Range(0, deadRats.Count - 1)];
	selectedDeadRat.tag = "DeadRat";
	Debug.Log ("Moving to Dead rat!");
	agent.actionContext.SetContextItem<GameObject>("move_target", selectedDeadRat);
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}