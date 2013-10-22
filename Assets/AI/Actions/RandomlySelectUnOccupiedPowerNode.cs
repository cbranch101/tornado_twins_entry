using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class RandomlySelectUnOccupiedPowerNode : RAIN.Action.Action
{

    public RandomlySelectUnOccupiedPowerNode()
    {
        actionName = "RandomlySelectUnOccupiedPowerNode";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
	List<GameObject> unOccupiedPowerNodes = agent.actionContext.GetContextItem<List<GameObject>>("un_occupied_power_nodes");
	if(unOccupiedPowerNodes.Count > 0) {
		setMoveTargetForRandomPowerNode(unOccupiedPowerNodes, agent);
		return RAIN.Action.Action.ActionResult.SUCCESS;
	} else {
		return RAIN.Action.Action.ActionResult.FAILURE;		
	}
    }
	
	void setMoveTargetForRandomPowerNode(List<GameObject >unOccupiedPowerNodes, RAIN.Core.Agent agent) {
		GameObject selectedPowerNode = null;
		float leastDistance = 100000f;;
		foreach(GameObject powerNode in unOccupiedPowerNodes) {
			Vector3 vectorDistance = agent.Avatar.gameObject.transform.position - powerNode.gameObject.transform.position;
			float distance = vectorDistance.sqrMagnitude;
			if(distance < leastDistance) {
				leastDistance = distance;
				selectedPowerNode = powerNode;
			}
		}	
		occupyPowerNode (selectedPowerNode, agent);
		agent.actionContext.SetContextItem<GameObject>("move_target", selectedPowerNode);
	}
	
	void occupyPowerNode(GameObject selectedPowerNode, RAIN.Core.Agent agent) {
		PowerNode powerNodeComponent = (PowerNode) selectedPowerNode.GetComponent("PowerNode");
		powerNodeComponent.isBeingEaten = true;
		agent.actionContext.SetContextItem<PowerNode>("current_power_node", powerNodeComponent);
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