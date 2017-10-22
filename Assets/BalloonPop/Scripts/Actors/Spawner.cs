using UnityEngine;

public class Spawner : MonoBehaviour {

    public SpawnObject spawnObject;
    public GameObject parent;
    public PooledPrefab pooledPrefab;
    public Vector2 horizontalViewPortRange = new Vector2(0.2f, 0.8f);
    public GameObjectEvent onGameObjectSpawned;

    private bool usePooledInstance;

    // Use this for initialization
    void Awake () {
        if (onGameObjectSpawned == null) {
            onGameObjectSpawned = new GameObjectEvent();
        }

        if (spawnObject.pooled && pooledPrefab != null) {
            pooledPrefab.prefab = spawnObject.prefab;
            usePooledInstance = true;
        } else {
            usePooledInstance = false;
        }
    }

    public void StartSpawner() {
        InvokeRepeating("SpawnObjects", 0.1f, spawnObject.spawnInternval);
    }

    public void StopSpawner() {
        if (IsInvoking("SpawnObjects")) {
            CancelInvoke();
        }
    }

    void SpawnObjects() {
        GameObject go;

        if (usePooledInstance) {
            go = pooledPrefab.GetInstance();
        } else {
            go = Instantiate(spawnObject.prefab);
        }

        go.transform.parent = parent.transform;
        go.transform.position = GetSpawnPosition();
        go.SetActive(true);

        onGameObjectSpawned.Invoke(go);
    }

    Vector3 GetSpawnPosition() {
        float xSpawnRange = Random.Range(horizontalViewPortRange.x, horizontalViewPortRange.y);
        Vector3 position = Camera.main.ViewportToWorldPoint(new Vector3(xSpawnRange, 0f, 0f));
        position.y = this.transform.position.y;

        return position;
    }
}
