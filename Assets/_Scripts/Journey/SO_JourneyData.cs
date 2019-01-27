using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "JourneyData", menuName = "Journey/Create JourneyData")]
public class SO_JourneyData : ScriptableObject
{
    [InlineEditor(InlineEditorModes.GUIOnly)]
    public SO_JourneyPoint[] JourneyPoints;
}
