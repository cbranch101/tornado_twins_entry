using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;
using RAIN.Path;

public class PlayerIsAimingAtAIWithWeapon : RAIN.Action.Action
{
    GameObject player;
	float angleThreshold = 10.0f;
	
	public PlayerIsAimingAtAIWithWeapon()
    {
        actionName = "PlayerIsAimingAtAIWithWeapon";
    }

    public bool playerIsFacingAgent(RAIN.Core.Agent agent) {
		RAINPathManager pathManager = agent.PathManager as RAINPathManager;

		player = GameObject.Find("PlayerConfigured");
		Vector3 targetDirection = player.transform.position - agent.Avatar.gameObject.transform.position;
		float angleBetweenPlayerAimAndAI = Vector3.Angle(targetDirection, player.transform.forward * -1);
		
		Vector3 badVector = new Vector3(15f, 19f, 31f);
		Debug.Log (pathManager.gridPathGraph);
		bool validLocation = (pathManager.gridPathGraph.Quantize(badVector) >= 0);
		
		return angleBetweenPlayerAimAndAI < angleThreshold;

	}
	
	public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
		if(playerIsFacingAgent(agent)) {

			return RAIN.Action.Action.ActionResult.SUCCESS;
		} else {

			return RAIN.Action.Action.ActionResult.SUCCESS;
		}

    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}