using UnityEngine;
using System.Collections;

public static class StaticScoreboard {
	public static UILabel ScoreLabel;
	public static UILabel HighScoreLabel;
	private static int score = 0;
	private static int highScore = 0;
	public static int planetsDestroyed = 0;

	public static void AddPoints(int points) {
		score += points;
		planetsDestroyed++;
		ScoreLabel.text = "CS " + score.ToString();
		CheckHighScore();
	}

	public static void ResetPoints() {
		CheckHighScore();
		score = 0;
		planetsDestroyed = 0;
		ScoreLabel.text = "CS " + score.ToString();
	}

	private static void CheckHighScore() {
		if (score > highScore)
		{
			highScore = score;
			HighScoreLabel.text = "HS "+highScore;
		}
	}
}