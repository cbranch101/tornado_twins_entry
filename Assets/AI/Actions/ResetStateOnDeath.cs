using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class ResetStateOnDeath : RAIN.Action.Action
{
    public ResetStateOnDeath()
    {
        actionName = "ResetStateOnDeath";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
	PowerNode currentPowerNode = agent.actionContext.GetContextItem<PowerNode>("current_power_node");
	if(currentPowerNode != null) {
		
		// reset the current power node	
		currentPowerNode.isBeingEaten = false;	
		currentPowerNode.sparkEffect.Stop();
			
	}
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}