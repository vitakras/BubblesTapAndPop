using UnityEngine;

public class Balloon : MonoBehaviour {

    Color color;
    new SpriteRenderer renderer;

    // Use this for initialization
    void Awake() {
        FindRenderer();
        Color = color;
    }

    public Color Color {
        set {
            color = value;
            renderer.color = color;
        }
        get {
            return color;
        }
    }

    void FindRenderer() {
        if (renderer == null) {
            renderer = GetComponent<SpriteRenderer>();
        }
    }
}
