using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PooledPrefab : MonoBehaviour {

    public int minPooledAmount = 20;
    public GameObject prefab;
    public GameObject parent;

    private Dictionary<int, GameObject> pooledObjects;
    private Stack<GameObject> availableObjects;

    // Use this for initialization
    void Start() {
        pooledObjects = new Dictionary<int, GameObject>();
        availableObjects = new Stack<GameObject>();

        for (int i = 0; i < minPooledAmount; i++) {
            CreateNewInstance();
        }
    }

    public GameObject GetInstance() {
        if (HasAvailableObject()) {
            return availableObjects.Pop();
        }

        return CreateNewInstance();
    }

    public void ReleaseInstance(GameObject go) {
        if (pooledObjects.ContainsKey(go.GetInstanceID())) {
            SetAvailable(go);
        }
    }

    GameObject CreateNewInstance() {
        GameObject go = GameObject.Instantiate(prefab);
        go.transform.parent = parent.transform;

        PooledInstance pooledInstance = go.GetComponent<PooledInstance>();
        if (pooledInstance == null) {
           pooledInstance = go.AddComponent<PooledInstance>();
        }
        pooledInstance.PooledPrefab = this;

        pooledObjects.Add(go.GetInstanceID(), go);
        SetAvailable(go);

        return go;
    }

    bool HasAvailableObject() {
        return availableObjects.Count > 0;
    }

    void SetAvailable(GameObject go) {
        if (go.activeSelf) {
            availableObjects.Push(go);
            go.SetActive(false);
        }
    }
}
