using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerNode : MonoBehaviour {
	
	
	float integrity = 100f;
	public bool isBeingEaten = false;
	public bool turnOff = false;
	bool isDestroyed = false;
	bool hasPower = false;
	public bool isPowerSource = false;
	public PowerNode[] childNodes;
	List<PowerNode> parentNodes = new List<PowerNode>();
	public GameObject connectedMachine;
	
	// Use this for initialization
	void Start () {
		
		if(isPowerSource) {
			addSelfAsParentToChildNodes();
		}
	}
	
	public void addParentNode(PowerNode parentNode) {
		parentNodes.Add(parentNode);
	}
	
	public void addSelfAsParentToChildNodes() {
		foreach(PowerNode powerNode in childNodes) {
			
			powerNode.addParentNode(this);
			powerNode.addSelfAsParentToChildNodes();
			updateCurrentPowerState();
			
		}
	}
	// Update is called once per frame
	void Update () {
			
	}
	
	public bool notDestroyed() {
		return !isDestroyed;
	}
	
	public bool atLeastOneParentNodeHasPower() {
		bool atLeastOneHasPower = false;
		foreach(PowerNode powerNode in parentNodes) {
			if(powerNode != null && !atLeastOneHasPower) {
				atLeastOneHasPower = powerNode.isPowered();
			}
		}
		
		return atLeastOneHasPower;
	}
	
	public void updateCurrentPowerState() {
		
		
		bool willBePowered = isPowerSource ? true : atLeastOneParentNodeHasPower();
		willBePowered = isDestroyed ? false : willBePowered; 
		
		if(hasPower) {
			if(!willBePowered) {
				powerDown();
			}
		} else {
			if(willBePowered) {
				powerUp();
			}
		}
		updatePowerStateForConnectedNodes();
	}
	
	public void takeDamage(float damageAmount) {
		integrity -= damageAmount;
		if(integrity <= 0f) {
			isDestroyed = true;
			updateCurrentPowerState();
		}
	}
	
	void updatePowerStateForConnectedNodes() {
		foreach(PowerNode powerNode in childNodes) {
			if(powerNode != null) {
				powerNode.updateCurrentPowerState();
			}
		}
	}
	
	public void powerDown() {
		hasPower = false;
		if(connectedMachine != null) {
			connectedMachine.SendMessage("OnPowerDown");
		}
	}
	
	public void powerUp() {
		hasPower = true;
		if(connectedMachine != null) {
			connectedMachine.SendMessage("OnPowerUp");
		}
	}
	
	public bool isPowered() {
		return hasPower;
	}
}
