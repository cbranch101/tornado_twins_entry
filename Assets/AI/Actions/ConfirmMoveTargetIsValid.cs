using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;
using RAIN.Path;

public class ConfirmMoveTargetIsValid : RAIN.Action.Action
{
	
	RAINPathManager pathManager;
	Vector2 moveTarget;
    public ConfirmMoveTargetIsValid()
    {
        actionName = "ConfirmMoveTargetIsValid";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
	pathManager = agent.PathManager as RAINPathManager;
	moveTarget = agent.actionContext.GetContextItem<Vector3>("move_target");
		
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
	if(pathManager.gridPathGraph == null || pathManager == null) {
		return RAIN.Action.Action.ActionResult.RUNNING;	
	} else {
		bool moveTargetIsValid = (pathManager.gridPathGraph.Quantize(moveTarget) >= 0);
		Debug.Log (moveTargetIsValid);
		return moveTargetIsValid ? RAIN.Action.Action.ActionResult.SUCCESS : RAIN.Action.Action.ActionResult.FAILURE; 		
	}
       
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}