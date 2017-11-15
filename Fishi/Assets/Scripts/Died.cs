using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Died : MonoBehaviour {

	[SerializeField] int highScore;
	[SerializeField] int score;
	[SerializeField] Text text;

	void OnEnable()
	{
		highScore = ScoreManager.highScore;
		score = ScoreManager.score;

		if (Player.gameFinished)
		{
			text.text = "GAME FINISHED!\n" + "WELL DONE\nHIGH SCORE: " + highScore + "!";
		}
		else if (score >= highScore)
		{
			text.text = "NEW HIGHSCORE!\n" + highScore + "!";	
		}
		else
		{
			text.text = "Score:\n" + score;
		}
	}
}
