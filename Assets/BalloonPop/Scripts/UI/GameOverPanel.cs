using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour {

    public Score score;
    public Text gameScore;
    public Text highScore;

    public void UpdateScore() {
        Debug.Log("called");
        this.gameScore.text = "" + score.GameScore;
        this.highScore.text = "BEST " + score.GetHighScore();
    }
}
