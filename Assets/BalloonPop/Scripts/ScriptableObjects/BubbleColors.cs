using UnityEngine;

[CreateAssetMenu(fileName = "NewBubbleColors.asset", menuName = "BubbleItems", order = 1)]
public class BubbleColors : ScriptableObject {

    public Color[] colors;

    public Color PickRandomColor() {
        int num = Random.Range(0, colors.Length);
        return colors[num];
    }
}
