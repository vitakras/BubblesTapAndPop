using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

    public UnityEvent onGameStarted;
    public UnityEvent onGameEnded;
    public GameObject[] resetablesGameObjects;

    private IResetable[] resetables;

    private void Start() {
        List<IResetable> resetableList = new List<IResetable>();
        foreach (GameObject go in resetablesGameObjects) {
            IResetable resetable = go.GetComponent<IResetable>();

            if (resetable != null) {
                resetableList.Add(resetable);
            }
        }

        resetables = resetableList.ToArray();

        if (onGameStarted == null) {
            onGameStarted = new UnityEvent();
        }

        if (onGameEnded == null) {
            onGameEnded = new UnityEvent();
        }
    }

    public void StartGame() {
        Debug.Log("Starting Game");
        foreach (IResetable resetable in resetables) {
            resetable.Reset();
        }

        onGameStarted.Invoke();

        foreach (IResetable resetable in resetables) {
            resetable.Enable();
        }
    }

    public void EndGame() {
        foreach (IResetable resetable in resetables) {
            resetable.Disable();
        }

        onGameEnded.Invoke();
    }
}
