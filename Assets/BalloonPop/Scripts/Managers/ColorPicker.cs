using UnityEngine;
using UnityEngine.Events;

public class ColorPicker : MonoBehaviour {

    public BubbleColors availableColors;
    public float colorRotateInterval = 5f;
    public UnityEvent onColorSelected;

    private Color activeColor;

    // Use this for initialization
    void Awake () {
        InvokeRepeating("RotateColors", colorRotateInterval, 0.3f);
    }

    public Color PickRandomColor() {
        return availableColors.PickRandomColor();
    }

    public Color ActiveColor {
        get {
            return activeColor;
        }
    }

    public bool IsActiveColor(Color color) {
        return color == activeColor;
    }

    void RotateColors() {
        activeColor = PickRandomColor();
    }
}
