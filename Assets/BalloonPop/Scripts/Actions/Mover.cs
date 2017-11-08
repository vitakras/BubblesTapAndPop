using UnityEngine;

public class Mover : MonoBehaviour {

    public Vector3 direction = Vector3.up;
    public BubbleSpeed bubbleSpeed;

    // Update is called once per frame
    void Update() {
        float speed = this.bubbleSpeed.speed * Time.deltaTime;
        transform.Translate(direction * speed, Space.World);
    }
}
