using UnityEngine;
using UnityEditor;

public class MakeBubbleColors {

    [MenuItem("Assets/Create/BubbleColors")]
    public static void CreateMyAsset() {
        BubbleColors asset = ScriptableObject.CreateInstance<BubbleColors>();

        AssetDatabase.CreateAsset(asset, "Assets/NewBubbleColors.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
