using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class ColorPicker : MonoBehaviour, IResetable {

    public BubbleColors availableColors;
    public float colorMinRotateInterval = 5f;
    public float colorMaxRotateInternal = 10f;
    public UnityEvent onColorSelected;

    private Color activeColor;
    private Color previousColor;
    private bool allowPreviousColor;
    private IEnumerator colorPicker;

    // Use this for initialization
    void Awake() {
        if (onColorSelected == null) {
            onColorSelected = new UnityEvent();
        }
        activeColor = PickRandomColor();
        Enable();
    }

    public void Reset() {
        Disable();
    }

    public void Disable() {
        if (colorPicker != null) {
            StopCoroutine(colorPicker);
            colorPicker = null;
        }
    }

    public void Enable() {
        if (colorPicker == null) {
            colorPicker = RotateColors();
            StartCoroutine(colorPicker);
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

    IEnumerator RotateColors() {
        while (true) {
            yield return new WaitForSeconds(GetRotateInterval());
            previousColor = activeColor;
            activeColor = PickRandomColor();
            onColorSelected.Invoke();
        }
    }

    float GetRotateInterval() {
        return Random.Range(colorMinRotateInterval, colorMaxRotateInternal);
    }

}
