using UnityEngine;
using UnityEngine.UI;

public class BubbleManager : MonoBehaviour {

    public GameManager gameManager;
    public ColorPicker colorPicker;
    public Score scoreManager;
    public Spawner spawner;

    private int score;

    void Awake() {
        ResetScore();
    }

    public void Reset() {
        this.score = 0;
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
    }

    void UpdateScore() {
        this.score++;
        this.scoreManager.GameScore = this.score;
    }
}
