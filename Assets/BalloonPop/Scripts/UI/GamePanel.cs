using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour {

    public int blinkCount = 3;
    public float blinkInternal = 0.3f;
    public Image activeColor;
    public ColorPicker colorPicker;

    private WaitForSeconds wait;

    void Awake() {
        wait = new WaitForSeconds(blinkInternal);
    }

    public void UpdateActiveColor() {
        if (gameObject.activeSelf) {
            StartCoroutine(BlinkToggle());
        } else {
            this.activeColor.color = colorPicker.ActiveColor;
        }
    }

    public void Reset() {
        this.activeColor.color = colorPicker.ActiveColor;
    }

    IEnumerator BlinkToggle() {
        colorPicker.AllowPreviousColor = true;
        for(int i =0; i < blinkCount; i++) {
            activeColor.enabled = false;
            yield return wait;
            activeColor.enabled = true;
            yield return wait;
        }

        this.activeColor.color = colorPicker.ActiveColor;
        colorPicker.AllowPreviousColor = false;
    }

}
