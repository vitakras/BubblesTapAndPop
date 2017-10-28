using UnityEngine;
using UnityEngine.UI;

public class BubbleManager : MonoBehaviour {

    public GameManager gameManager;
    public ColorPicker colorPicker;
    public Score scoreManager;
    public Spawner spawner;
    public Text scoreText;

    private int score;

    void Awake() {
        ResetScore();
        spawner.StartSpawner();
    }

    public void Reset() {
        this.score = 0;
        this.scoreText.text = "" + score;
    }

    public void HandleClickedBubble(GameObject go) {
        Bubble bubble = go.GetComponent<Bubble>();
        if (bubble == null) {
            return;
        }

        if (colorPicker.IsActiveColor(bubble.Color)) {
            UpdateScore();
        } else {
            gameManager.EndGame();
        }

        bubble.Pop();
    }

    public void ConfigureBubble(GameObject go) {
        Bubble bubble = go.GetComponent<Bubble>();
        if (bubble == null) {
            return;
        }

        UpdateBubbleColor(bubble);
    }

    void UpdateBubbleColor(Bubble bubble) {
        bubble.Color = colorPicker.PickRandomColor();
    }

    void ResetScore() {
        this.score = 0;
        this.scoreText.text = "" + score;
    }

    void UpdateScore() {
        this.score++;
        this.scoreText.text = "" + score;
        this.scoreManager.GameScore = this.score;
    }
}
