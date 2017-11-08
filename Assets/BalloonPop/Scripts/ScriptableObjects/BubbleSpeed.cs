using UnityEngine;

[CreateAssetMenu(fileName = "newBubbleSpeed.asset", menuName = "BubbleSpeed", order = 4)]
public class BubbleSpeed : ScriptableObject {

    public float speed;
    public float minSpeed;
    public float maxSpeed;

    public void ResetSpeed() {
        speed = minSpeed;
    }
}
