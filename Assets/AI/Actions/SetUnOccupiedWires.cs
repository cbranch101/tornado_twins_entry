using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class SetUnOccupiedWires : RAIN.Action.Action
{
    
	
	List<GameObject> unOccupiedWires;
	
	public SetUnOccupiedWires()
    {
        actionName = "SetUnOccupiedWires";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {

	setUnOccupiedWires(agent);
	return RAIN.Action.Action.ActionResult.SUCCESS;
    }
	
	void setUnOccupiedWires(RAIN.Core.Agent agent) {
		unOccupiedWires = new List<GameObject>();
		List<GameObject> objectsToDestroy = agent.actionContext.GetContextItem<List<GameObject>>("objects_to_destroy");		
		foreach(GameObject objectToDestroy in objectsToDestroy){
			Wire wireComponent = (Wire) objectToDestroy.GetComponent("Wire");
			
			if(wireComponent != null && !wireComponent.isBeingEaten) {
				unOccupiedWires.Add (objectToDestroy);	
			}
		}
		
		agent.actionContext.SetContextItem<List<GameObject>>("un_occupied_wires", unOccupiedWires);
		
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