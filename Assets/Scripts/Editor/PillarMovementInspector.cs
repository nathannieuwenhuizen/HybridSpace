using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(PillarMovement))]
public class PillarMovementInspector : Editor
{
    private bool showDeafault = false;
    public override void OnInspectorGUI()
    {
        PillarMovement myScript = (PillarMovement)target;
        if (GUILayout.Button("toggle default values"))
        {
            showDeafault = !showDeafault;
        }

        if (showDeafault)
        {
            DrawDefaultInspector();
        }

        EditorGUILayout.HelpBox("Illusion calls", MessageType.Info);

        GUILayout.Label("Pillar is " + (myScript.moved ? "illusion" : "real"));
        if (GUILayout.Button("Move"))
        {
            myScript.Move();
        }
        //GUILayout.Label("Pillar is " + (myScript.moved ? "illusion" : "real"));
        //if (GUILayout.Button("Move"))
        //{
        //    myScript.Move();
        //}
    }
}