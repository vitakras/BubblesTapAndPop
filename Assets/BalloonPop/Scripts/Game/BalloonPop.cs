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

    // Use this for initialization
    void Start() {
        text = init;
       // active = colors[0];
      //  StartCoroutine(Fade());
    }

    void Update() {

    }

    public void PauseGame() { 
        if (isGameRunning) {
            isGameRunning = false;
            StopCoroutine(GameLoop());
        }
    }

    public void ResumeGame() {
        if (!isGameRunning) {
            isGameRunning = true;
            StartCoroutine(GameLoop());
        }
    }


    IEnumerator GameLoop() {
        while(isGameRunning) {
            yield return null;
        }
    }

    public void DebugTouch(GameObject go) {
        if (go == null) {
            return;
        
        }
        Debug.Log(go.tag);
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
}
