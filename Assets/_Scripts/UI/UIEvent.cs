using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class UIEvent 
{
    public string Title;
    public string Description;
    public List<Outcome> Outcomes;

    //private void Awake()
    //{
    //    string json = JsonUtility.ToJson(this);
    //    Debug.Log(json);
    //}
}
