using UnityEngine;
using System.Collections;

public class ScoreUI : MonoBehaviour {

    public UILabel ScoreLabel;
	public UILabel HighScoreLabel;
	public UILabel gameplayHint;

    void Awake() {
    	if(StaticScoreboard.ScoreLabel == null) {
			StaticScoreboard.ScoreLabel = this.ScoreLabel;
		}
		if(StaticScoreboard.HighScoreLabel == null) {
			StaticScoreboard.HighScoreLabel = this.HighScoreLabel;
		}
		GameObject.Destroy (gameplayHint, 5f);
	}
}
