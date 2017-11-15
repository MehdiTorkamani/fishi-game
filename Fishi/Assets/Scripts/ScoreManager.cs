using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour {

	[SerializeField] Text scoreText;
	[SerializeField] Text highScoreText;

	public static int score;
	public static int highScore;

	void Awake()
	{
		scoreText.text = "Score: 0";
		highScoreText.text = "HighScore: 0";
	}

	void Update () {
		score = Convert.ToInt32 (Player.dist);
		scoreText.text = "Score: " + score;

		if (score > highScore) {
			highScore = score;
			highScoreText.text = "High Score: " + highScore;
		}
	}
}
