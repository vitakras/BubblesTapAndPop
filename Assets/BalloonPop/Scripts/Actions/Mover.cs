using UnityEngine;

public class Mover : MonoBehaviour {

    public Vector3 direction = Vector3.up;
    public BubbleSpeed bubbleSpeed;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        float speed = this.bubbleSpeed.speed * Time.deltaTime;
        //transform.Translate(direction * speed, Space.World);

        rb.MovePosition(transform.position + direction * speed);
    }
}
