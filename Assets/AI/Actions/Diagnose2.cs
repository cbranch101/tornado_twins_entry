using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class Diagnose2 : RAIN.Action.Action
{
    public Diagnose2()
    {
        actionName = "Diagnose2";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
       	Debug.Log ("starting 2");
		return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
        Debug.Log ("running 2");
		return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
       Debug.Log ("stop 2");
		return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}