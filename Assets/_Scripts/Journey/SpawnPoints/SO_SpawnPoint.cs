using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnPoint", menuName = "Game/Spawn/Create Point")]
public class SO_SpawnPoint : ScriptableObject
{
    public Vector3 Point;
    public Vector3 Direction;
}
