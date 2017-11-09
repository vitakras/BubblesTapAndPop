using UnityEngine;
using UnityEngine.UI;
using System;

public class ScorePanel : MonoBehaviour {

    public Score score;
    public Text scoreText;

    public void UpdateScore() {
        this.scoreText.text = String.Format("{0}", score.GameScore);
    }
}
