using UnityEngine;

public class PooledInstance : MonoBehaviour {

    private PooledPrefab pooledPrefab;

    public PooledPrefab PooledPrefab {
        set {
            pooledPrefab = value;
        }
    }

    public void Destory() {
        if (pooledPrefab != null) {
            pooledPrefab.ReleaseInstance(gameObject);
        }
    }
}
