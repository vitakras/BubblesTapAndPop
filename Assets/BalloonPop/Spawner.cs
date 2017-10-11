﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject prefab;
    public BalloonPop balloon;

	// Use this for initialization
	void Start () {
        StartCoroutine(Fade());
    }


    IEnumerator Fade() {
        yield return new WaitForSeconds(1);

        int num = Random.Range(5, 10);

        for (int i = 0; i <= num; i++){
            int pos = Random.Range(-5, 5);
            yield return new WaitForSeconds(0.4f);
            GameObject go = GameObject.Instantiate(prefab);
            go.transform.position = (Vector3.left * pos) + (Vector3.up * -5f);

            Float fl = go.GetComponent<Float>();
            fl.UpdateColor(balloon.RandomColor());
        }

        StartCoroutine(Fade());
    }
}
