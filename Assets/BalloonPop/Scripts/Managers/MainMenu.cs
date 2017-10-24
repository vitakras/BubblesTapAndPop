using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void LoadGameLevel() {
        SceneManager.LoadScene("GameScene");
    }
}
