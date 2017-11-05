using UnityEngine;
using UnityEngine.Events;

public class ColorPicker : MonoBehaviour {

    public BubbleColors availableColors;
    public float colorRotateInterval = 5f;
    public UnityEvent onColorSelected;

    private Color activeColor;
    private Color previousColor;
    private bool allowPreviousColor;

    // Use this for initialization
    void Awake () {
        InvokeRepeating("RotateColors", 0.3f, colorRotateInterval);
        if (onColorSelected == null) {
            onColorSelected = new UnityEvent();
        }
    }

    public Color PickRandomColor() {
        return availableColors.PickRandomColor();
    }

    public Color ActiveColor {
        get {
            return activeColor;
        }
    }

    public bool AllowPreviousColor {
        set {
            allowPreviousColor = value;
        }
        get {
            return allowPreviousColor;
        }
    }

    public bool IsActiveColor(Color color) {
        if (allowPreviousColor) {
            return (color == activeColor) || (color == previousColor);
        }

        return color == activeColor;
    }

    void RotateColors() {
        previousColor = activeColor;
        activeColor = PickRandomColor();
        onColorSelected.Invoke();
    }
}
