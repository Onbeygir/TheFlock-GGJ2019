using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector.Editor;

[CustomEditor(typeof(Weapon))]
public class WeaponEditor : OdinEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Draw Weapon Arc"))
        {
            var weapon = Selection.activeGameObject.GetComponent<Weapon>();
            var wDirection = weapon.WeaponDirection;
            Debug.DrawRay(weapon.gameObject.transform.position,wDirection, Color.green, 3f);
            //weapon.WeaponFireArcInDegrees
        }
    }
}
