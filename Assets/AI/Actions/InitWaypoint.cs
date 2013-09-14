using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;
using RAIN.Path;

public class InitWaypoint : RAIN.Action.Action
{
    
	List<GameObject> waypoints = new List<GameObject>();
	
	public InitWaypoint()
    {
        actionName = "InitWaypoint";
    }

    public override RAIN.Action.Action.ActionResult Start(RAIN.Core.Agent agent, float deltaTime)
    {
		
		RAIN.Path.RAINPathManager currentPathManager = (RAIN.Path.RAINPathManager)agent.PathManager;
		GameObject waypointCollection = currentPathManager.waypointCollection;
		foreach(Transform waypointTransform in waypointCollection.transform) {
			waypoints.Add(waypointTransform.gameObject);
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