using UnityEngine;

public class Score : MonoBehaviour {

    private int score;
    private int highscore;

    // Use this for initialization
    void Awake() {
        ResetScore();
        ResetHighScore();
    }

    public int GameScore {
        set {
            score = value;

            if (score > highscore) {
                highscore = score;
            }
        }
        get {
            return score;
        }
    }

    public int GetHighScore() {
        return this.highscore;
    }

    public void SetHighScore(int highscore) {
        this.highscore = highscore;
    }

    public void ResetScore() {
        this.score = 0;
    }

    public void ResetHighScore() {
        this.highscore = 0;
    }
}
