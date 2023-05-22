using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(TowerScript))]
[CanEditMultipleObjects]
public class TowerScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TowerScript tower = (TowerScript)target;
        GUILayout.BeginHorizontal();

        if(GUILayout.Button("Furthest Target")) {
            tower.ChangeTargetType("Furthest");
        }

        if(GUILayout.Button("Closest Target")) {
            tower.ChangeTargetType("Closest");
        }

        if(GUILayout.Button("Random Target")) {
            tower.ChangeTargetType("Random");
        }

        GUILayout.EndHorizontal();
    }
}
