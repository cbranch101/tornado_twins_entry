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
	public ParticleSystem sparkEffect;
	
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
			if(powerNode != null) {
				powerNode.addParentNode(this);
				powerNode.addSelfAsParentToChildNodes();
								
			}
		}
		updateCurrentPowerState();
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
		Debug.Log (gameObject.name + " " + willBePowered);
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
		sparkEffect.Play ();
		if(integrity <= 0f) {
			sparkEffect.Stop();
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
		Debug.Log (gameObject.name + " powering down");
		hasPower = false;
		if(connectedMachine != null) {

			connectedMachine.SendMessage("OnPowerDown");
		}
	}
	
	public void powerUp() {
		Debug.Log (gameObject.name + " powering up");
		hasPower = true;
		if(connectedMachine != null) {
			connectedMachine.SendMessage("OnPowerUp");
		}
	}
	
	public bool isPowered() {
		return hasPower;
	}
}
