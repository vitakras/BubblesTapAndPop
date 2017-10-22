using UnityEngine;

public class DestoryByBoundry : MonoBehaviour {

    void OnTriggerExit2D(Collider2D collision) {
        PooledInstance instance = collision.gameObject.GetComponent<PooledInstance>();
        if (instance != null) {
            instance.Destory();
        } else {
            GameObject.Destroy(collision.gameObject);
        }
    }
}
