using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLoader : MonoBehaviour {


	public Text lastScoreText, bestScoreText;


	private int lastScore, bestScore;

	// Use this for initialization
	void Awake() {

		LoadScore();

		bestScoreText.text = "Best score\n" + bestScore.ToString();
		lastScoreText.text = "Last score\n" + lastScore.ToString();
	}


	private void LoadScore(){
		lastScore = PlayerPrefs.GetInt("LastScore");
		bestScore = PlayerPrefs.GetInt("BestScore");
	}
}
