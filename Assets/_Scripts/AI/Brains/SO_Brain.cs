using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class SO_Brain : ScriptableObject
{
    public List<SO_BaseBehaviour> BehaviourList;
    public abstract Vector3 DoThinking(AIController ctrl);
    
}
