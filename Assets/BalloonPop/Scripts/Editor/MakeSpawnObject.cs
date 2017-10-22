using UnityEngine;
using UnityEditor;

public class MakeSpawnObject {

    [MenuItem("Assets/Create/SpawnObject")]
    public static void CreateMyAsset() {
        SpawnObject asset = ScriptableObject.CreateInstance<SpawnObject>();

        AssetDatabase.CreateAsset(asset, "Assets/NewSpawnObject.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
