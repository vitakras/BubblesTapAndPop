using UnityEngine;

public class Mover : MonoBehaviour {

    public Vector3 direction = Vector3.up;
    public float speed = 5f;

    // Update is called once per frame
    void Update() {
        float speed = this.speed * Time.deltaTime;
        transform.Translate(direction * speed, Space.World);
    }
}
