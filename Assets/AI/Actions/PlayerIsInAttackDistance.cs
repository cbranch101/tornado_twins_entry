using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class PlayerIsInAttackDistance : RAIN.Action.Action
{
    public PlayerIsInAttackDistance()
    {
        actionName = "PlayerIsInAttackDistance";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
	
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
	GameObject player = agent.actionContext.GetContextItem<GameObject>("player");
	float distanceToPlayer = Vector3.Distance(player.transform.position, agent.Avatar.gameObject.transform.position);
	Debug.Log (distanceToPlayer);
		BigEnemyAI ai = (BigEnemyAI) agent.Avatar.gameObject.GetComponent("BigEnemyAI"); 
	if(distanceToPlayer <= ai.attackDistance) {
		return RAIN.Action.Action.ActionResult.SUCCESS;			
	} else {
		return RAIN.Action.Action.ActionResult.FAILURE;		
	}
        
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}