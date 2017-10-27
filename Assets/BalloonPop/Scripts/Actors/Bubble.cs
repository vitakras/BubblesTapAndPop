using System;
using System.Collections;
using UnityEngine;

public class Bubble : MonoBehaviour {

    private new AudioSource audio;
    private Color color;
    private new SpriteRenderer renderer;
    private PooledInstance pooledInstance;

    // Use this for initialization
    void Awake() {
        FindRenderer();
        pooledInstance = GetComponent<PooledInstance>();
        audio = GetComponent<AudioSource>();
    }

    public Color Color {
        set {
            color = value;
            renderer.color = color;
        }
        get {
            return color;
        }
    }

    void FindRenderer() {
        if (renderer == null) {
            renderer = GetComponent<SpriteRenderer>();
        }
    }


    public void Pop() {
        if (this.audio != null) {
            audio.Play();
            StartCoroutine(PopBubble());   
        }
    }

    IEnumerator PopBubble() {
        if (this.audio.isPlaying) {
            yield return null;
        }
        //pooledInstance = GetComponent<PooledInstance>();
        //if (pooledInstance != null) {
        //    pooledInstance.Destory();
        //}
    }
}
