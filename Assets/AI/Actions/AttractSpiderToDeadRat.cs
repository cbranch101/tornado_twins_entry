using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class AttractSpiderToDeadRat : RAIN.Action.Action
{
    public AttractSpiderToDeadRat()
    {
        actionName = "AttractSpiderToDeadRat";
    }
	

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
	GameObject[] spiders = GameObject.FindGameObjectsWithTag("Spider");
	foreach(GameObject spider in spiders) {
		RAINAgent spiderAgent = (RAINAgent) spider.GetComponent("RAINAgent");
		GameObject existingRatToEat = spiderAgent.mind.actionContext.GetContextItem<GameObject>("rat_to_eat");
		if(existingRatToEat == null) {
			spiderAgent.mind.actionContext.SetContextItem<GameObject>("rat_to_eat", agent.Avatar.gameObject);		
			break;
		}
	}
        return RAIN.Action.Action.ActionResult.SUCCESS;
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