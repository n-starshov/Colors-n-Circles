using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using NUnit.Framework.Internal.Filters;
using System;
using Random = UnityEngine.Random;


public class GameController : MonoBehaviour {

	public static GameController instance = null;
	public GameObject[] enemiesForSpawn;
	public int countEnemies;
	public Vector3 endOfGameBGHealthScale;
	public GameObject stickControll;


	private GameObject player; //, backgroundHealth;
	private Text scoreText;// ,endText;
	private Color textColor;
	private int currentCountEnemies;
	private bool isGameOver;


	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
		
		#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER

		stickControll.SetActive(false);

		#elif UNITY_IOS

		System.Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");

		#endif


		scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
		scoreText.text = "0";

		player = GameObject.FindGameObjectWithTag("Player");
		player.SetActive(true);

		spawnEnemyRandomly(8);
		isGameOver = false;
	}


	void Update(){
		
		if (isGameOver) {
			SceneManager.LoadScene("HomeScene");
		}
	}


	private void SaceScore(){
		
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

//			float min = 0.50f;
//			float max = 1.50f;
			GameObject randomEnemy = enemiesForSpawn[UnityEngine.Random.Range(0, enemiesForSpawn.Length)];
//			randomEnemy.gameObject.transform.localScale *= Random.Range(min, max);

			Instantiate(randomEnemy, enemyPosition, UnityEngine.Quaternion.identity);
		}
	}

	
	public void IncreaseTextScore(){
		int score = int.Parse(scoreText.text);
		score++;
		scoreText.text = score.ToString();
	}


	public void AddEnemy(EnemyController enemy){
//		enemiesForSpawn.a(enemy);
	}


	public void EnemyIsDead(EnemyController enemy){
		
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
//		#if !UNITY_WEBPLAYER

		string filePath = Application.persistentDataPath + "/Score.txt";
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

//		#endif
	}
}
