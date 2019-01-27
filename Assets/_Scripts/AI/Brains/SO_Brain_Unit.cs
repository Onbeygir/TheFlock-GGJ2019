using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Brain_", menuName = "AI/Unit Brain" )]
public class SO_Brain_Unit : SO_Brain
{
    public override Vector3 DoThinking(AIController ctrl)
    {
        int randomBehIndex = Random.Range(0, BehaviourList.Count);

        return BehaviourList[randomBehIndex].DoBehaviour();
    }

}
