using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

    public UnityEvent onGameStarted;
    public UnityEvent onGameEnded;

    private void Start() {
        if (onGameStarted == null) {
            onGameStarted = new UnityEvent();
        }

        if (onGameEnded == null) {
            onGameEnded = new UnityEvent();
        }
    }

    public void StartGame() {
        onGameStarted.Invoke();
    }

    public void EndGame() {
        onGameEnded.Invoke();
    }
}
