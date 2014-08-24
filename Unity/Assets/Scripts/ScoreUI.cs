using UnityEngine;
using System.Collections;

public class ScoreUI : MonoBehaviour {

    public UILabel ScoreLabel;

    void Awake() {
		StaticScoreboard.ScoreLabel = this.ScoreLabel;
	}
}
