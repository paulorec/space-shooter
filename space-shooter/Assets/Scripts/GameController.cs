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

	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;

	void Start() {
		score = 0;
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";

		updateScore ();

		StartCoroutine ( SpawnWaves ());

	}

	void Update() {
		
		if (restart) {
			
			if (Input.GetKeyDown (KeyCode.R)) {
				
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	public void GameOver() {
		score = 0;
		gameOver = true;
		gameOverText.text = "Game Over";

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

				if (gameOver) {

					restartText.text = "Press R for restart";

					restart = true;

					break;
				}
			}

			yield return new WaitForSeconds(wavesWait);


		}
		

	}
}
