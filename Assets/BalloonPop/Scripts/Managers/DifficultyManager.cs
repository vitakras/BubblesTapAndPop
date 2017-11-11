using UnityEngine;

public class DifficultyManager : MonoBehaviour, IResetable {

    public int increaseEvery = 2;
    public float increaseBy = 0.3f;
    public BubbleSpeed bubbleSpeed;

	// Use this for initialization
	void Start () {
        Reset();
	}

    public void Reset() {
        bubbleSpeed.speed = bubbleSpeed.minSpeed;
    }

    public void CheckDifficultyIncrease(int score) {
        if (score > 0 && (score % increaseEvery) == 0) {
            IncreaseDifficulty();
        }
    }

    void IncreaseDifficulty() {
        if (bubbleSpeed.speed < bubbleSpeed.maxSpeed) {
            bubbleSpeed.speed += increaseBy;
        }
    }

    public void Disable() {
    }

    public void Enable() {
    }
}
