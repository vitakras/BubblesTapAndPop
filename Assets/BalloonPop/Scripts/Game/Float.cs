using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour {

    public Vector3 direction = Vector3.up;
    public float speed = 5f;


    public void UpdateColor(Color color) {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = color;
    }

	// Use this for initialization
	void Start () {
        //UpdateColor(BalloonPop.active);
    }
	
	// Update is called once per frame
	void Update () {
        float speed = this.speed * Time.deltaTime;
        transform.Translate(direction * speed, Space.World);
    }

    void OnMouseDown() {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (renderer.color != BalloonPop.active) {
            BalloonPop.text.text = "You Lose";
        }

        Destroy(this.gameObject);
    }
}
