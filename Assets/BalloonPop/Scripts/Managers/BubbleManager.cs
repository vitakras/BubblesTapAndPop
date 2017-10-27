using UnityEngine;
using UnityEngine.UI;

public class BubbleManager : MonoBehaviour {

    public BubbleColors availableColors;
    public Spawner spawner;
    public Image activeBubbleImage;
    public Text scoreText;

    private bool paused = false;
    private Color selectedColor;
    private int score;

    void Awake() {
        PickRandomColor();
        ResetScore();
        spawner.StartSpawner();
    }

    public void Pause() {
        paused = true;
        spawner.StopSpawner();
    }

    public void Resume() {
        paused = false;
        spawner.StartSpawner();
    }

    public void HandleClickedBubble(GameObject go) {
        if (!paused) {
            Bubble bubble = go.GetComponent<Bubble>();
            if (bubble == null) {
                return;
            }

            if (bubble.Color == selectedColor) {
                UpdateScore();
            } else {
                Debug.Log("You Lose");
            }

            bubble.Pop();
        }
    }

    public void ConfigureBubble(GameObject go) {
        Bubble bubble = go.GetComponent<Bubble>();
        if (bubble == null) {
            return;
        }

        UpdateBubbleColor(bubble);
    }

    void UpdateBubbleColor(Bubble bubble) {
        bubble.Color = availableColors.PickRandomColor();
    }

    void ResetScore() {
        this.score = 0;
        this.scoreText.text = "" + score;
    }

    void UpdateScore() {
        this.score++;
        this.scoreText.text = "" + score;
    }

    void PickRandomColor() {
        selectedColor = availableColors.PickRandomColor();
        activeBubbleImage.color = selectedColor;
    }
}
