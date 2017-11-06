using System;
using UnityEngine;

public class Bubble : MonoBehaviour {

    private Color color;
    private new SpriteRenderer renderer;
    private PooledInstance pooledInstance;
    private AudioSource audioSource;

    // Use this for initialization
    void Awake() {
        FindRenderer();
        pooledInstance = GetComponent<PooledInstance>();
        audioSource = GetComponent<AudioSource>();
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
        this.audioSource.Play();

        pooledInstance = GetComponent<PooledInstance>();
        if (pooledInstance != null) {
            pooledInstance.Destory(this.audioSource.clip.length);
        }
    }
}
