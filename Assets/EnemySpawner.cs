using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject spiderPrefab;
	
	public void spawnSpider() {
		Instantiate(spiderPrefab, gameObject.transform.position, gameObject.transform.rotation);
	}
	
}
