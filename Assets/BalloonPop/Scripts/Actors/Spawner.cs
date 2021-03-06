using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour, IResetable {

    public SpawnObject spawnObject;
    public GameObject parent;
    public PooledPrefab pooledPrefab;
    public Vector2 horizontalViewPortRange = new Vector2(0.2f, 0.8f);
    public GameObjectEvent onGameObjectSpawned;

    private bool usePooledInstance;
    private WaitForSeconds startWait;
    private WaitForSeconds spawnWait;
    private WaitForSeconds waveWait;
    private IEnumerator spawner;

    // Use this for initialization
    void Awake() {
        if (onGameObjectSpawned == null) {
            onGameObjectSpawned = new GameObjectEvent();
        }

        if (spawnObject.pooled && pooledPrefab != null) {
            pooledPrefab.prefab = spawnObject.prefab;
            usePooledInstance = true;
        }
        else {
            usePooledInstance = false;
        }

        startWait = new WaitForSeconds(spawnObject.startWait);
        spawnWait = new WaitForSeconds(spawnObject.spawnWait);
        waveWait = new WaitForSeconds(spawnObject.waveWait);

        StartSpawner();
    }

    public void Reset() {
    }

    public void Disable() {
        StopSpawner();
    }

    public void Enable() {
        StartSpawner();
    }

    public void StartSpawner() {
        if (spawner == null) {
            spawner = SpawnWaves();
            StartCoroutine(spawner);
        }
    }

    public void StopSpawner() {
        if (spawner != null) {
            StopCoroutine(spawner);
            spawner = null;
        }
    }

    void SpawnObjects() {
        GameObject go;

        if (usePooledInstance) {
            go = pooledPrefab.GetInstance();
        }
        else {
            go = Instantiate(spawnObject.prefab);
        }

        go.transform.parent = parent.transform;
        go.transform.position = GetSpawnPosition();
        go.SetActive(true);

        onGameObjectSpawned.Invoke(go);
    }

    IEnumerator SpawnWaves() {
        yield return startWait;

        while (true) {
            for (int i = 0; i < spawnObject.waveSpawnCount; i++) {
                GameObject go = SpawnObject();
                InitializeObject(go);
                yield return new WaitForSeconds(spawnObject.waveWait);
            }
            //yield return waveWait;
        }
    }

    GameObject SpawnObject() {
        GameObject go;

        if (usePooledInstance) {
            go = pooledPrefab.GetInstance();
        }
        else {
            go = Instantiate(spawnObject.prefab);
        }

        return go;
    }

    void InitializeObject(GameObject go) {
        go.transform.parent = parent.transform;
        go.transform.position = GetSpawnPosition();
        go.SetActive(true);

        onGameObjectSpawned.Invoke(go);
    }

    Vector3 GetSpawnPosition() {
        float xSpawnRange = Random.Range(horizontalViewPortRange.x, horizontalViewPortRange.y);
        Vector3 position = Camera.main.ViewportToWorldPoint(new Vector3(xSpawnRange, 0f, 0f));
        position.y = this.transform.position.y;
        position.z = 0f;

        return position;
    }
}
