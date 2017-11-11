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
    private bool isActive;

    // Use this for initialization
    void Awake() {
        if (onColorSelected == null) {
            onColorSelected = new UnityEvent();
        }

        Enable();
    }

    public void Reset() {
        Disable();
    }

    public void Disable() {
        if (isActive) {
            isActive = false;
            StopCoroutine(RotateColors());
        }
    }

    public void Enable() {
        if (!isActive) {
            isActive = true;
            StartCoroutine(RotateColors());
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
        while (isActive) {
            previousColor = activeColor;
            activeColor = PickRandomColor();
            onColorSelected.Invoke();

            yield return new WaitForSeconds(GetRotateInterval());
        }
    }

    float GetRotateInterval() {
        return Random.Range(colorMinRotateInterval, colorMaxRotateInternal);
    }

}
