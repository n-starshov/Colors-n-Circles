using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLoader : MonoBehaviour {


	public Text lastScoreText, bestScoreText;

	// Use this for initialization
	void Awake() {
		string[] scores = { "0", "0" };
			
		try{
			scores = System.IO.File.ReadAllLines("Score.txt");
		} catch {
		
		}
		int bestScore = int.Parse(scores[0]);
		int lastScore = int.Parse(scores[1]);

		bestScoreText.text = "Best score\n" + bestScore.ToString();
		lastScoreText.text = "Last score\n" + lastScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
