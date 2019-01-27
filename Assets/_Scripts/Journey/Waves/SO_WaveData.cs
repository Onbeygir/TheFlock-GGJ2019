using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Wave 1", menuName = "Game/Wave/Create Wave")]
public class SO_WaveData : ScriptableObject
{
    [System.Serializable]
    public class EnemyDataPositionPair
    {
        [InlineEditor(InlineEditorModes.GUIOnly)]
        public SO_EnemyVehicleData EnemyData;
        public SO_SpawnPoint SpawnPoint;
    }

    public EnemyDataPositionPair[] WaveEnemies;
}
