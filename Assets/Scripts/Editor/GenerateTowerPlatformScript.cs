using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(GenerateTowerOfPlatforms))]
[CanEditMultipleObjects]
public class GenerateTowerPlatformScript : Editor {
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GenerateTowerOfPlatforms myScript = (GenerateTowerOfPlatforms)target;
        if (GUILayout.Button("Build Object"))
        {
            myScript.DestroyPlatforms();
            myScript.Create();
        }
    }
}
