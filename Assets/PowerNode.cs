using UnityEngine;
using System.Collections;

public class PowerNode : MonoBehaviour {
	
	
	float integrity = 100f;
	public bool isBeingEaten = false;
	public bool turnOff = false;
	bool isDestroyed = false;
	bool hasPower = false;
	public bool isPowerSource = false;
	public PowerNode[] connectedNodes;
	public GameObject connectedMachine;
	
	// Use this for initialization
	void Start () {
		if(isPowerSource) {
			updateCurrentPowerState(true);
		}
	}
	// Update is called once per frame
	void Update () {
			
	}
	
	public bool notDestroyed() {
		return !isDestroyed;
	}
	
	public void updateCurrentPowerState(bool willBePowered) {
		
		if(!isDestroyed) {
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
	}
	
	public void takeDamage(float damageAmount) {
		integrity -= damageAmount;
		if(integrity <= 0f) {
			updateCurrentPowerState(false);
			isDestroyed = true;
		}
	}
	
	void updatePowerStateForConnectedNodes() {
		foreach(PowerNode powerNode in connectedNodes) {
			if(powerNode != null) {
				powerNode.updateCurrentPowerState(hasPower);
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
