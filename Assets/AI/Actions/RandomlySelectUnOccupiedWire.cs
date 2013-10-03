using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class RandomlySelectUnOccupiedWire : RAIN.Action.Action
{
    public RandomlySelectUnOccupiedWire()
    {
        actionName = "RandomlySelectUnOccupiedWire";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
	List<GameObject> unOccupiedWires = agent.actionContext.GetContextItem<List<GameObject>>("un_occupied_wires");
	GameObject selectedWire = unOccupiedWires[Random.Range(0, unOccupiedWires.Count - 1)];
	occupyWire (selectedWire);
	agent.actionContext.SetContextItem<GameObject>("move_target", selectedWire);
	return RAIN.Action.Action.ActionResult.SUCCESS;

    }
	
	void occupyWire(GameObject selectedWire) {
		Wire wireComponent = (Wire) selectedWire.GetComponent("Wire");
		wireComponent.isBeingEaten = true;
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