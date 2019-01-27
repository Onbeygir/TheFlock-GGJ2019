using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFactory : MonoBehaviour
{
    public void CreateWave(SO_WaveData data)
    {
        foreach (var item in data.WaveEnemies)
        {
            GameObject enemy = Instantiate(item.EnemyData.Prefab);
            enemy.transform.position = item.SpawnPoint.Point;
            var eu = enemy.GetComponent<EnemyUnit>();
            eu.OnCreated(item.EnemyData, item.SpawnPoint.Direction);
        }
    }

    
}
