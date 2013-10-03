using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class SetUnOccupiedPowerNodes : RAIN.Action.Action
{
    
	
	List<GameObject> unOccupiedPowerNodes;
	
	public SetUnOccupiedPowerNodes()
    {
        actionName = "SetUnOccupiedPowerNodes";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
	return RAIN.Action.Action.ActionResult.SUCCESS;
    }
	
	List<GameObject> getUnOccupiedPowerNodes(RAIN.Core.Agent agent) {
		unOccupiedPowerNodes = new List<GameObject>();
		List<GameObject> objectsToDestroy = agent.actionContext.GetContextItem<List<GameObject>>("objects_to_destroy");		
		foreach(GameObject objectToDestroy in objectsToDestroy){
			PowerNode powerNodeComponent = (PowerNode) objectToDestroy.GetComponent("PowerNode");
			
			if(powerNodeComponent != null && !powerNodeComponent.isBeingEaten && powerNodeComponent.notDestroyed()) {
				unOccupiedPowerNodes.Add (objectToDestroy);	
			}
		}
		
		return unOccupiedPowerNodes;
		
	}

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
	List<GameObject> unOccupiedPowerNodes = getUnOccupiedPowerNodes(agent);
	
	if(unOccupiedPowerNodes.Count > 0) {
		agent.actionContext.SetContextItem<List<GameObject>>("un_occupied_power_nodes", unOccupiedPowerNodes);
		return RAIN.Action.Action.ActionResult.SUCCESS;
	} else {
		return 	RAIN.Action.Action.ActionResult.FAILURE;	
	}

    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}