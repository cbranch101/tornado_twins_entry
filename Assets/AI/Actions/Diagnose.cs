using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class Diagnose : RAIN.Action.Action
{
    public Diagnose()
    {
        actionName = "Diagnose";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
       Debug.Log("started");
		return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
		Debug.Log("running");
        return RAIN.Action.Action.ActionResult.RUNNING;
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
		Debug.Log("finished");
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}