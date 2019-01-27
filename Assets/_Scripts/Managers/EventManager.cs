using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public delegate void UpdateResourceAction(int amount, UIResourceType uIResourceType);
    public static event UpdateResourceAction OnUpdateResource;

    public static void UpdateResource(int amount, UIResourceType uIResourceType)
    {
        if (OnUpdateResource != null)
            OnUpdateResource.Invoke(amount, uIResourceType);
    }
}
