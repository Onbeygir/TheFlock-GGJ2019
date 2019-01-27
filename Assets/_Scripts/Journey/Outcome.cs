using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class Outcome
{
    [LabelText("ResourceType")]
    public List<UIResourceType> uIResourceType;
    public List<int> value;
    public bool isNotForced = false;
    public int NextEvent;
   
    public string OutComeText;
}
