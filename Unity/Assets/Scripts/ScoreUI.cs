using UnityEngine;
using System.Collections;

public class ScoreUI : MonoBehaviour {

    public UILabel ScoreLabel;
	public UILabel HighScoreLabel;

    void Awake() {
		StaticScoreboard.ScoreLabel = this.ScoreLabel;
		StaticScoreboard.HighScoreLabel = this.HighScoreLabel;
	}
}
