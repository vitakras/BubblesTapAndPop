using UnityEngine;

public class Score : MonoBehaviour {

    public IntegerEvent onScoreUpdated;

    private int score;
    private int highscore;
    private const string scoreString = "score";

    // Use this for initialization
    void Start() {
        if (onScoreUpdated == null) {
            onScoreUpdated = new IntegerEvent();
        }

        Load();
        ResetScore();
    }

    public int GameScore {
        set {
            score = value;

            if (score > highscore) {
                highscore = score;
                Save();
            }

            onScoreUpdated.Invoke(score);
        }
        get {
            return score;
        }
    }

    public int GetHighScore() {
        return this.highscore;
    }

    public void ResetScore() {
        this.GameScore = 0;
    }

    public void ResetHighScore() {
        this.highscore = 0;
    }

    public void Load() {
        highscore = PlayerPrefs.GetInt(scoreString, 0);
    }

    void Save() {
        PlayerPrefs.SetInt(scoreString, highscore);
    }
}
