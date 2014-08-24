using UnityEngine;
using System.Collections;

public static class StaticScoreboard {
	public static UILabel ScoreLabel;

	private static int score = 0;
	public static int planetsDestroyed = 0;

	public static void AddPoints(int points) {
		score += points;
		planetsDestroyed++;
		ScoreLabel.text = score.ToString();
	}

	public static void ResetPoints() {
		score = 0;
		planetsDestroyed = 0;
		ScoreLabel.text = "Score: " + score;
	}
}