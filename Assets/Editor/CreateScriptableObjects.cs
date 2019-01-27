using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateScriptableObjects 
{
    [MenuItem("PoC/Data/CreateResourceData")]
    public static void CreateResourceData()
    {
        ScriptableObjectUtility.CreateAsset<SO_ResourceData>();
    }
}
