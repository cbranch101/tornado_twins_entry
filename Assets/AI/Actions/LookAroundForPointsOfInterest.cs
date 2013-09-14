using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class LookAroundForPointsOfInterest : RAIN.Action.Action
{
    public float rotateSpeed = 0.3f;
	public Vector3 searchTarget;
	public bool lookedAround = false;
	
	public LookAroundForPointsOfInterest()
    {
        actionName = "LookAroundForPointsOfInterest";
    }
			
	public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
		
		return RAIN.Action.Action.ActionResult.SUCCESS;
    }
	
	void updateSearchTarget(RAIN.Core.Agent agent) {
		
		Transform agentTransform = agent.Avatar.gameObject.transform;
		Vector3 transformDirection = agent.actionContext.GetContextItem<bool>("should_turn_right") ? agentTransform.right : agentTransform.right * -1;
		searchTarget = agent.Avatar.gameObject.transform.position - transformDirection;

	}
	
    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
		
		
		updateSearchTarget(agent);
		lookedAround = agent.LookAt(searchTarget, Time.deltaTime * rotateSpeed);
		return RAIN.Action.Action.ActionResult.SUCCESS;
        
    }

    public override RAIN.Action.Action.ActionResult Stop(RAIN.Core.Agent agent, float deltaTime)
    {
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}