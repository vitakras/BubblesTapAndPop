using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {

    public BubbleSpeed bubbleSpeed;

	// Use this for initialization
	void Start () {
        Reset();
	}

    public void Reset() {
        bubbleSpeed.speed = bubbleSpeed.minSpeed;
    }
}
