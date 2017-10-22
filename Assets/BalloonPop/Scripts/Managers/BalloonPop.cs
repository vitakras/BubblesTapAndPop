using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalloonPop : MonoBehaviour {

    public Color[] colors;
    public Image image;
    public Text init;

    public static Color active;
    public static Text text;

    private bool isGameRunning = false;

    private float timeScale = -1f;

    // Use this for initialization
    void Start() {
        timeScale = -1;
    }

    void Update() {

    }

    public void PauseGame() {
        PauseTimeScale();
    }

    public void ResumeGame() {
        ResumeTimeScale();
    }


    //IEnumerator Fade() {
    //    int num = Random.Range(0, colors.Length);
    //    active = colors[num];

    //    image.color = active;
    //    yield return new WaitForSeconds(5);
    //    StartCoroutine(Fade());
    //}

    //public Color RandomColor() {
    //    int num = Random.Range(0, colors.Length);
    //    return colors[num];
    //}

    void PauseTimeScale() {
        if (this.timeScale == -1) {
            this.timeScale = Time.timeScale;
        }
        Time.timeScale = 0f;
    }

    void ResumeTimeScale() {
        if (this.timeScale != -1) {
            Time.timeScale = this.timeScale;
        }
    }
}
