using UnityEngine;
using System.Collections;
using FPSControl;
using RAIN.Core;
using System.Collections.Generic;

public class BigEnemyAI : EnemyAI {
	
	
	public float attackDistance = 5f;
	public float avoidAngle = 10f;
	
	protected override void setStartingActionContext() {
		
	}
	
	
	protected override void OnAIUpdate() {
		actionContext.SetContextItem<bool>("is_being_aimed_at", playerIsAimingAtMe());
		actionContext.SetContextItem<bool>("is_in_attack_distance_of_player", iAmInAttackDistanceOfPlayer());
	}
	
	protected override void OnTakeDamage(float currentHealth, float damageAmount) {
			
	}
	
	public bool playerIsAimingAtMe() {
		Vector3 targetDirection = player.transform.position - agent.avatar.gameObject.transform.position;
		float angleBetweenPlayerAimAndAI = Vector3.Angle(targetDirection, player.transform.forward * -1);	
		return angleBetweenPlayerAimAndAI < avoidAngle;

	}
	
	public bool iAmInAttackDistanceOfPlayer() {
		float distanceToPlayer = Vector3.Distance(player.transform.position, agent.avatar.gameObject.transform.position); 
		return distanceToPlayer <= attackDistance;
	}
}
