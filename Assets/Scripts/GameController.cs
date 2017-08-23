using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using NUnit.Framework.Internal.Filters;
using System;


public class GameController : MonoBehaviour {


	public GameObject[] enemies;
	public int countEnemies;


	private GameObject player;
	private Text startGameText, scoreText;
	private bool isGameOver, goToPlay;
	private int currentCountEnemies;


	void Start(){
		startGameText = GameObject.Find("StartGameText").GetComponent<Text>();
		startGameText.text = "Press Space to Start";

		scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
		scoreText.text = "0";

		player = GameObject.FindGameObjectWithTag("Player");
		player.SetActive(false);

		isGameOver = false;
		goToPlay = false;
	}


	void Update(){
		if (Input.GetKey(KeyCode.Space) && !goToPlay) {
			startGameText.text = "";
			player.SetActive(true);
			spawnEnemyRandomly(10);
			goToPlay = true;
		}

		if (isGameOver) {
			SceneManager.LoadScene(0);
		}
	}


	public void spawnEnemyRandomly(int count=1){
		for (int i = 0; i < count; i++) {
			Vector3 enemyPosition = UnityEngine.Random.onUnitSphere * 150;
			if (enemyPosition.x < enemyPosition.y) {
				enemyPosition.x += enemyPosition.z;
			} else {
				enemyPosition.y += enemyPosition.z;
			}

			enemyPosition.x = (Math.Abs(enemyPosition.x) <= 100 ? (100 * Mathf.Sign(enemyPosition.x)) : enemyPosition.x);
			enemyPosition.y = (Math.Abs(enemyPosition.y) <= 100 ? (100 * Mathf.Sign(enemyPosition.y)) : enemyPosition.y);
			enemyPosition.z = 0.0f;

			Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length)], enemyPosition, UnityEngine.Quaternion.identity);
		}
	}

	
	public void IncreaseTextScore(){
		int score = int.Parse(scoreText.text);
		score++;
		scoreText.text = score.ToString();
	}


	public void GameOver(){
		isGameOver = true;
	}
}
