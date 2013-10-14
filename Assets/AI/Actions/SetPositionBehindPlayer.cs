using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;
using RAIN.Path;

public class SetPositionBehindPlayer : RAIN.Action.Action
{
    	public SetPositionBehindPlayer()
    	{
        	actionName = "SetPositionBehindPlayer";
    	}

    	public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    	{
		GameObject player = agent.actionContext.GetContextItem<GameObject>("player");
		Vector3 positionBehindPlayer = getPositionBehindPlayer(player);
		bool positionIsValid = true;
		RAINPathManager pathManager = agent.PathManager as RAINPathManager;
		
		if ((pathManager != null) && (pathManager.gridPathGraph != null)) {
			Debug.Log (pathManager.gridPathGraph.Quantize(positionBehindPlayer) >= 0);
			positionIsValid = (pathManager.gridPathGraph.Quantize(positionBehindPlayer) >= 0);
			Debug.Log (positionIsValid);
		}
		
		if(positionIsValid) {
			agent.actionContext.SetContextItem<Vector3>("move_target", positionBehindPlayer);
			return RAIN.Action.Action.ActionResult.SUCCESS;
		} else {
			return RAIN.Action.Action.ActionResult.FAILURE;
		}		
    	}
	
	Vector3 getPositionBehindPlayer(GameObject player) {
		Vector3 playerPosition = player.transform.position;
		Vector3 playerDirection = player.transform.forward;
		Vector3 positionBehindPlayer = playerPosition - (playerDirection * 2);
		return positionBehindPlayer;
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