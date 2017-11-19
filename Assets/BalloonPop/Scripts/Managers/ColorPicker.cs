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
    private int activeColorProbability = 30;
    private int[] selectColorProbability;

    // Use this for initialization
    void Awake() {
        if (onColorSelected == null) {
            onColorSelected = new UnityEvent();
        }
        UpdateActiveColor();
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

    public Color PickRandomColorWithProbability() {
        if (selectColorProbability == null) {
            return availableColors.PickRandomColor();
        }

        int index = RandomWithProbability(selectColorProbability);
        return availableColors.colors[index];
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
            UpdateActiveColor();
            onColorSelected.Invoke();
        }
    }

    float GetRotateInterval() {
        return Random.Range(colorMinRotateInterval, colorMaxRotateInternal);
    }

    void UpdateActiveColor() {
        previousColor = activeColor;
        activeColor = PickRandomColor();
        BuildColorProbability();
    }

    void BuildColorProbability() {
        selectColorProbability = new int[availableColors.colors.Length];

        int probability = (100 - activeColorProbability) / (availableColors.colors.Length - 1);

        for (int i = 0; i < selectColorProbability.Length; i++) {
            if (availableColors.colors[i] == activeColor) {
                selectColorProbability[i] = activeColorProbability;
            }
            else {
                selectColorProbability[i] = probability;
            }
        }
    }

    int RandomWithProbability(int[] probability) {
        int range = (int)(Random.Range(0f, 1f) * 100);
        for (int i = 0, sum = 0; i < probability.Length; i++) {
            if (IsWithin(range, sum, sum + probability[i])) {
                return i;
            }

            sum += probability[i];
        }

        return probability.Length - 1;
    }

    public static bool IsWithin(int value, int minimum, int maximum) {
        return value >= minimum && value <= maximum;
    }
}
