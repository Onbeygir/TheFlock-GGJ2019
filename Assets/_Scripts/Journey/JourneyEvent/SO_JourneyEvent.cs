using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "JourneyEvent 1", menuName = "Journey/Create a Journey Event")]
public class SO_JourneyEvent : SO_JourneyPoint
{
    public TextAsset JourneyJSON;
    [InfoBox("If Null Event Pop up will open. Else, A Town prefab will enter the screen and shop Windown Will Open")]
    public GameObject TownPrefab;
}
