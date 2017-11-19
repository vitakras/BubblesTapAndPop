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
        Vector3 offset = direction * bubbleSpeed.speed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + offset);
    }
}
