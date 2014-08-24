using UnityEngine;
using System.Collections;

public class ScoreUI : MonoBehaviour {

    public UILabel ScoreLabel;
	public UILabel HighScoreLabel;
	public UILabel gameplayHint;

    void Awake() {
		StaticScoreboard.ScoreLabel = this.ScoreLabel;
		StaticScoreboard.HighScoreLabel = this.HighScoreLabel;
		GameObject.Destroy (gameplayHint, 5f);
	}
}
