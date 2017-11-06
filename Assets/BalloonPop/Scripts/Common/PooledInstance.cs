using System.Collections;
using UnityEngine;

public class PooledInstance : MonoBehaviour {

    private PooledPrefab pooledPrefab;
    private bool destroying;

    public PooledPrefab PooledPrefab {
        set {
            pooledPrefab = value;
        }
    }

    public void Destory(float destroyIn = 0f) {
        if (!destroying) {
            StartCoroutine(DestoryInstance(destroyIn));
        }
    }

    IEnumerator DestoryInstance(float destoryIn) {
        destroying = true;

        if (destoryIn > 0) {
            yield return new WaitForSeconds(destoryIn);
        }

        if (pooledPrefab != null) {
            pooledPrefab.ReleaseInstance(gameObject);
        }

        destroying = false;
    }
}
