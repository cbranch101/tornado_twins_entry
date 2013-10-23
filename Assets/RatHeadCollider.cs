using UnityEngine;
using System.Collections;
using FPSControl;
using RAIN.Core;
using System.Collections.Generic;

public class RatHeadCollider : MonoBehaviour {
	
	public SmallEnemyAI aiComponent;
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void ApplyDamage(DamageSource damageSource) {
		Debug.Log ("firing");
		aiComponent.SendMessage("ApplyDamage", damageSource);
	}

}
