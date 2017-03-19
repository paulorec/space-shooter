using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;

	public int hazardsCount;
	public int wavesWait;
	public int spawnWait;
	public GUIText scoreText;
	private int score;

	void Start() {
		score = 0;
		updateScore ();

		StartCoroutine ( SpawnWaves ());

	}

	public void AddScore(int newScore) {
		score += newScore;
		updateScore ();
	}

	void updateScore() {
		scoreText.text = "Score: " + score;
	}

	IEnumerator SpawnWaves() {


		while(true) {

			for (int k = 0; k < hazardsCount; k++) {

				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

				Quaternion spawnRotation = Quaternion.identity;

				Instantiate (hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnWait);
			}

			yield return new WaitForSeconds(wavesWait);
		}
		

	}
}
