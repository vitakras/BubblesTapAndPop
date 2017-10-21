using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalloonPop : MonoBehaviour {

    public MouseHandler touchHandler;
    public Color[] colors;
    public Image image;
    public Text init;

    public static Color active;
    public static Text text;

    // Use this for initialization
    void Start() {
        text = init;
       // active = colors[0];
      //  StartCoroutine(Fade());
    }

    void Update() {
        if (touchHandler) {
            if (touchHandler.GetObjectsBeingTouched().Length > 0) {
                Debug.Log("touched");
            }
       
        }
   
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
