using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class DamagePowerNode : RAIN.Action.Action
{
    	
	PowerNode currentPowerNode;
	float damageToApply;
	public DamagePowerNode()
    	{
        	actionName = "DamagePowerNode";
   	}

   	public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    	{
        	SmallEnemyAI smallEnemyAI = (SmallEnemyAI)agent.Avatar.gameObject.GetComponent("SmallEnemyAI");
		damageToApply = smallEnemyAI.powerNodeDamage;
		currentPowerNode = agent.actionContext.GetContextItem<PowerNode>("current_power_node");
		return RAIN.Action.Action.ActionResult.SUCCESS;
    	}

    	public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    	{
		currentPowerNode.takeDamage(damageToApply);
		if(currentPowerNode.notDestroyed()) {
			return RAIN.Action.Action.ActionResult.FAILURE;
		} else {
			return RAIN.Action.Action.ActionResult.SUCCESS;
		}
        	
    	}

    	public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    	{
        	return RAIN.Action.Action.ActionResult.SUCCESS;
    	}
}