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
	public Vector3 endOfGameBGHealthScale;


	private GameObject player; //, backgroundHealth;
	private Text scoreText;// ,endText;
	private Color textColor;
	private int currentCountEnemies;
	private bool isGameOver;


	void Awake(){
//		endText = GameObject.Find("EndText").GetComponent<Text>();
//		endText.text = "";
//		var color = endText.color;
//		color.a = 0.0f;
//		endText.color = color;

		scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
		scoreText.text = "0";

		player = GameObject.FindGameObjectWithTag("Player");
		player.SetActive(true);

//		backgroundHealth = GameObject.Find("BackgroundHealth");


		spawnEnemyRandomly(8);
		isGameOver = false;
	}


	void Update(){
		
		if (isGameOver) {
			SceneManager.LoadScene("HomeScene");
//			endText.text = "Score:\n" + scoreText.text;
//
//			backgroundHealth.transform.localScale = Vector3.Lerp (backgroundHealth.transform.localScale, endOfGameBGHealthScale, 0.2f * Time.deltaTime);
//
//			var color = scoreText.color;
//			color.a = Mathf.Lerp(color.a, 0.0f, Time.deltaTime);
//			scoreText.color = color;
//
//			color = endText.color;
//			color.a = Mathf.Lerp(color.a, 1.0f, Time.deltaTime);
//			endText.color = color; 
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
		foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Blue")){
			enemy.SetActive(false);
		}
		foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Red")){
			enemy.SetActive(false);
		}

		// save score to file
		string filePath = "Score.txt";
		string[] scores;
		try{
			scores = System.IO.File.ReadAllLines(filePath);
		} catch {
			scores = new string[1] {"0"};
		}

		int bestScore = int.Parse(scores[0]);
		int currentScore = int.Parse(scoreText.text);
		if (currentScore > bestScore) {
			bestScore = currentScore;
		}
		System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true);
		file.WriteLine(bestScore + "\n" + currentScore);
		file.Close();
	}
}
