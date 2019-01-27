using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraShaker))]
public class CameraShakerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Shake"))
        {
            var shaker = Selection.activeGameObject.GetComponent<CameraShaker>();
            shaker.DoShake(.2f);
        }

    }
}
