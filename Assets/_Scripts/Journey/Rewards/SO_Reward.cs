using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Reward 1", menuName = "Rewards/Create a Reward")]
public class SO_Reward : ScriptableObject
{
    public List<UIResourceType> uIResourceType;
    public List<int> value;
}
