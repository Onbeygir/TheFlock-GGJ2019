using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class SO_ResourceData : ScriptableObject
{
    [BoxGroup("ResourceData")]
    [PropertyRange(3,7)]
    public int People;
    [BoxGroup("ResourceData")]
    [PropertyRange(10, 50)]
    public int Scrap;
    [BoxGroup("ResourceData")]
    [PropertyRange(10, 50)]
    public int Fuel;
    [BoxGroup("ResourceData")]
    [PropertyRange(10, 50)]
    public int Food;
}
