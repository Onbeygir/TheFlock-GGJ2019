using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Encounter 1", menuName = "Game/Encounter/Create Encounter Data")]
public class SO_EncounterData : SO_JourneyPoint
{
    [InlineEditor(InlineEditorModes.GUIOnly)]
    public SO_WaveData[] Waves;
    [InlineEditor(InlineEditorModes.GUIOnly)]
    public SO_Reward[] Rewards;
    [InlineEditor(InlineEditorModes.GUIOnly)]
    public AudioClip Music;
}
