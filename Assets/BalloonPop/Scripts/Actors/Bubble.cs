using UnityEngine;

public class Bubble : MonoBehaviour {

    private Color color;
    private new SpriteRenderer renderer;

    // Use this for initialization
    void Awake() {
        FindRenderer();
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
