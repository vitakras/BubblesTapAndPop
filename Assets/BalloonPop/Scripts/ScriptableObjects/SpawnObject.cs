using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnObject.asset", menuName = "SpawnObject", order = 2)]
public class SpawnObject : ScriptableObject {

    public GameObject prefab;
    public bool pooled;
    public float spawnInternval;
}
