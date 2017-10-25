using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Spawner spawner;
    public BubbleColors availableColors;

    private void Awake() {
        spawner.StartSpawner();
    }

    public void LoadGameLevel() {
        SceneManager.LoadScene("GameScene");
    }

    public void ConfigureBubble(GameObject go) {
        Bubble bubble = go.GetComponent<Bubble>();
        if (bubble == null) {
            return;
        }

        UpdateBubbleColor(bubble);
    }

    void UpdateBubbleColor(Bubble bubble) {
        bubble.Color = availableColors.PickRandomColor();
    }
}
