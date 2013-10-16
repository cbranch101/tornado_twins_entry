using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;
using System.Collections.Generic;

public class SetDeadRats : RAIN.Action.Action
{
    
	List<GameObject> deadRats;
	
	public SetDeadRats()
    {
        actionName = "SetDeadRats";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
        deadRats = new List<GameObject>();
	GameObject[] allDeadRats = GameObject.FindGameObjectsWithTag("AvailableDeadRat");
	foreach(GameObject deadRat in allDeadRats) {
		deadRats.Add(deadRat);
	}
	return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute(RAIN.Core.Agent agent, float deltaTime)
    {
	if(deadRats.Count > 0) {
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