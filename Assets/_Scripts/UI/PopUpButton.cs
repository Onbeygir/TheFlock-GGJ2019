using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PopUpButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Button button;
    private Button Button { get { return (button) ?? GetComponent<Button>(); } }

    private Text buttontext;
    private Text ButtonText { get { return (buttontext) ?? GetComponentInChildren<Text>(); } }

    private ResourcesSpeaker resourcesSpeaker;
    public ResourcesSpeaker ResourcesSpeaker { get { return (resourcesSpeaker) ?? GetComponent<ResourcesSpeaker>(); } }

    int _id;
    UIPopUp _uIPopUp;


    public void SetUpButton(string text, int id, bool interactable)
    {
        ButtonText.text = text;
        _id = id;
        _uIPopUp = GetComponentInParent<UIPopUp>();
        Button.interactable = interactable;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _uIPopUp.DisplayText(_id);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _uIPopUp.HideText();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(Button.interactable)
            _uIPopUp.InvokeButton(_id);
    }
}
