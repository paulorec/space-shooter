using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;

	public int wavesInterval;

	void Start() {
				
		StartCoroutine ( SpawnWaves ());

	}

	IEnumerator SpawnWaves() {
		
		while(true) {
			
			Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

			Quaternion spawnRotation = Quaternion.identity;

			Instantiate (hazard, spawnPosition, spawnRotation);

			yield return new WaitForSeconds(wavesInterval);
		}
		

	}
}
