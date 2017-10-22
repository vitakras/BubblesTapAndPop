using UnityEngine;

public class BubbleManager : MonoBehaviour {

    public BubbleColors availableColors;
    public Spawner spawner;

    private bool paused = false;
    private Color selectedColor;

    void Awake() {
        selectedColor = availableColors.PickRandomColor();
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
            Debug.Log("clicked" + go.tag);
        }
    }

    public void UpdateBubbleColor(Bubble bubble) {
        bubble.Color = availableColors.PickRandomColor();
    }
}
