using UnityEngine;

public class DifficultyManager : MonoBehaviour, IResetable {

    public int increaseEvery = 2;
    public float increaseBy = 0.3f;
    public Spawner spawner;
    public BubbleSpeed bubbleSpeed;
    public SpawnObject easyDificulty;
    public SpawnObject mediumDificulty;

    private bool dificultySet = false;

	// Use this for initialization
	void Start () {
        Reset();
	}

    public void Reset() {
        spawner.spawnObject = easyDificulty;
        bubbleSpeed.speed = bubbleSpeed.minSpeed;
        dificultySet = false;
    }

    public void CheckDifficultyIncrease(int score) {
        if (score > 0 && (score % increaseEvery) == 0) {
            IncreaseDifficulty();
        }

        if (score > 30 && dificultySet == false) {
            spawner.spawnObject = mediumDificulty;
            dificultySet = true;
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
