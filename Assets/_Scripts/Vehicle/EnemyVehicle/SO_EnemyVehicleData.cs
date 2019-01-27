using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Enemy 1", menuName = "Game/EnemyData/New Enemy Data")]
public class SO_EnemyVehicleData : SO_VehicleData
{
    [InlineEditor(InlineEditorModes.GUIOnly)]
    public SO_Reward Reward;
    //todo
}
