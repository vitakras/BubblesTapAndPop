using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour {

    public BubbleColors availableColors;

    private bool paused = false;
    private Color selectedColor;

    void Awake() {
        selectedColor = availableColors.PickRandomColor();
    }

    public void Pause() {
        paused = true;
    }

    public void Resume() {
        paused = false;
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
