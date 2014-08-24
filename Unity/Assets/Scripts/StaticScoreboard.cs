using UnityEngine;
using System.Collections;

public static class StaticScoreboard {
	public static UILabel ScoreLabel;

	private static int score = 0;

	public static void AddPoints(int points) {
		score += points;
		ScoreLabel.text = "Score: " + score;
	}

	public static void ResetPoints() {
		score = 0;
		ScoreLabel.text = "Score: " + score;
	}
}