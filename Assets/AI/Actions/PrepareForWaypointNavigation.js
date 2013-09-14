import System.Collections.Generic;
import RAIN.Action;
import RAIN.Core;

class PrepareForWaypointNavigation extends RAIN.Action.Action
{
	private var waypoints : List.<GameObject>;
	
	function newclass() {
		actionName = "PrepareForWaypointNavigation";
	}
	
	function setWaypoints(agent : Agent) {
		waypoints = new List.<GameObject>();
		var pathManager : RAIN.Path.PathManager = agent.PathManager;
       	var waypointCollection : GameObject = pathManager.waypointCollection;
       	
       	for (var child : Transform in waypointCollection.transform) {
       		var waypoint : GameObject = child.gameObject;
       		waypoints.Add(waypoint);
       	}
	} 
	
	function Start(agent : Agent, deltaTime : float) : ActionResult {       
        this.setWaypoints(agent);   
        return ActionResult.SUCCESS;
	}

	function Execute(agent : Agent, deltaTime : float) : ActionResult {
        return ActionResult.SUCCESS;
	}

   	function Stop(agent:Agent, deltaTime:float):ActionResult {
        return ActionResult.SUCCESS;
	}
}