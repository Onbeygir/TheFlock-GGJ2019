using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesSpeaker : MonoBehaviour
{
    Button button;

    Button Button { get { return (button) ?? button.GetComponent<Button>(); } }

    public void Invoke(int amount, UIResourceType uIResourceType)
    {
        UpdateResource(amount, uIResourceType);
    }

    public void UpdateResource(int amount, UIResourceType uIResourceType)
    {
        EventManager.UpdateResource(amount, uIResourceType);
    }
}
