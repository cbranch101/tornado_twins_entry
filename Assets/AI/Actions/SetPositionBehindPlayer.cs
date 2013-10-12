using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

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
		agent.actionContext.SetContextItem<Vector3>("move_target", positionBehindPlayer);
		agent.actionContext.SetContextItem<bool>("move_target_is_valid", true);
		return RAIN.Action.Action.ActionResult.SUCCESS;
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