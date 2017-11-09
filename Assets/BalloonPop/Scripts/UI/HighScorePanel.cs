using UnityEngine;
using UnityEngine.UI;

public class HighScorePanel : MonoBehaviour {

    public string prefix = "BEST: ";
    public Score score;
    public Text highScoreText;

    void Awake() {
        score.Load();
        UpdateHighScore();    
    }

    public void UpdateHighScore() {
        this.highScoreText.text = string.Format("{0}{1}", prefix, score.GetHighScore());
    }
}
