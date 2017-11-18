using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour {

    public int blinkCount = 3;
    public float blinkInternal = 0.3f;
    public Image activeColor;
    public ColorPicker colorPicker;

    private WaitForSeconds wait;
    private IEnumerator blinkToggle;

    void Awake() {
        wait = new WaitForSeconds(blinkInternal);
    }

    void OnEnable() {
        UpdateColor();
        Debug.Log("started Game Panel");
    }

    void OnDisable() {
        if (blinkToggle != null) {
            StopCoroutine(blinkToggle);
            blinkToggle = null;
        }
    }

    public void UpdateActiveColor() {
        if (gameObject.activeSelf && this.activeColor) {
            if (blinkToggle != null) {
                StopCoroutine(blinkToggle);
            }

            blinkToggle = BlinkToggle();
            StartCoroutine(blinkToggle);
        }
        else {
            UpdateColor();
        }
    }

    IEnumerator BlinkToggle() {
        colorPicker.AllowPreviousColor = true;

        for (int i = 0; i < blinkCount; i++) {
            activeColor.enabled = false;
            yield return wait;
            activeColor.enabled = true;
            yield return wait;
        }

        UpdateColor();
        colorPicker.AllowPreviousColor = false;
    }

    void UpdateColor() {
        this.activeColor.color = colorPicker.ActiveColor;
        Debug.Log(this.activeColor.color);
    }
}
