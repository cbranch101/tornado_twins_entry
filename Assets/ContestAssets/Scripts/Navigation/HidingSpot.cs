using UnityEngine;
using System.Collections;

public class HidingSpot : MonoBehaviour {
	
	public float colliderRadius = .50f;
	SphereCollider collider;
	
	// Use this for initialization
	void Start () {
		collider = gameObject.GetComponent<SphereCollider>();
		collider.radius = colliderRadius;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, colliderRadius);
	}
}
