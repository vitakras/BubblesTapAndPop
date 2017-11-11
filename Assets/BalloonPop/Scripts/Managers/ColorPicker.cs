using UnityEngine;
using UnityEngine.Events;

public class ColorPicker : MonoBehaviour, IResetable {

    public BubbleColors availableColors;
    public float colorRotateInterval = 5f;
    public UnityEvent onColorSelected;

    private Color activeColor;
    private Color previousColor;
    private bool allowPreviousColor;

    // Use this for initialization
    void Awake () {
        if (onColorSelected == null) {
            onColorSelected = new UnityEvent();
        }

        Enable();
    }

    public void Reset() {
        CancelInvoke();
    }

    public void Disable() {
       CancelInvoke();
    }

    public void Enable() {
        InvokeRepeating("RotateColors", 0.3f, colorRotateInterval);
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
        Debug.Log("called");
    }

}
