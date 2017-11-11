using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour, IResetable {

    public int blinkCount = 3;
    public float blinkInternal = 0.3f;
    public Image activeColor;
    public ColorPicker colorPicker;

    private WaitForSeconds wait;
    private bool isActive;
    private bool colorSet;

    void Awake() {
        wait = new WaitForSeconds(blinkInternal);
        Enable();
    }

    public void UpdateActiveColor() {
        if (gameObject.activeSelf && this.activeColor) {
            StartCoroutine(BlinkToggle());
        }
        else {
            this.activeColor.color = colorPicker.ActiveColor;
        }
    }

    public void Reset() {
        this.colorSet = false;
        this.activeColor.color = colorPicker.ActiveColor;
    }

    public void Disable() {
        this.isActive = false;
    }

    public void Enable() {
        this.isActive = true;
        Reset();
    }

    IEnumerator BlinkToggle() {
        colorPicker.AllowPreviousColor = true;

        if (colorSet) {
            for (int i = 0; i < blinkCount; i++) {
                activeColor.enabled = false;
                yield return wait;
                activeColor.enabled = true;
                yield return wait;
            }
        }

        this.activeColor.color = colorPicker.ActiveColor;
        colorPicker.AllowPreviousColor = false;
        colorSet = true;
    }
}
