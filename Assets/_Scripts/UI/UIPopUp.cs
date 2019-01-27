using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using UnityEngine.Events;

public class UIPopUp : MonoBehaviour
{

    [Header("Data")]
    public TextAsset Data;

    

    [Header("UI Components")]
    public Text TitleText;
    public Text Description;
    public SetUpText OutComeText;

    [Header("Event")]
    public UnityEvent UIEventEnded;

    [SerializeField]
    private int _nextEvent;

    [SerializeField]
    private GameObject _buttonPrefab;

    [SerializeField]
    private Transform _buttonHolder;

    private UIEvent _uiEvent;

    private Panel _panel;
    private Panel Panel { get { return (_panel == null) ? _panel = GetComponent<Panel>() : _panel; } }

    List<PopUpButton> popUpButtons = new List<PopUpButton>();

    public void AssignData(TextAsset data)
    {
        Data = data;
    }

    public void InvokeButton(int buttonId)
    {
        for (int i = 0; i < _uiEvent.Outcomes[buttonId].value.Count; i++)
        {
            popUpButtons[buttonId].ResourcesSpeaker.Invoke(_uiEvent.Outcomes[buttonId].value[i], _uiEvent.Outcomes[buttonId].uIResourceType[i]);
            
        }
        SetNextEvent(_uiEvent.Outcomes[buttonId].NextEvent);
    }

    public void SetNextEvent(int eventId)
    {
        if (eventId == 0)
            UIManager.Instance.HidePopUp();
        else
        {
            UIManager.Instance.OpenPopUp(eventId);
            Debug.Log("Countinue event opened");
        }
    }

    [Button(ButtonSizes.Medium)]
    public void Deserialize()
    {
        string json = Data.ToString();

        UIEvent uiEvent = JsonUtility.FromJson<UIEvent>(json);

        _uiEvent = new UIEvent();

        _uiEvent.Title = uiEvent.Title;
        _uiEvent.Description = uiEvent.Description;
        _uiEvent.Outcomes = uiEvent.Outcomes;
    }

    public void SetUpPopUp()
    {
        TitleText.text = _uiEvent.Title;
        Description.text = _uiEvent.Description;

        for (int i = 0; i < _uiEvent.Outcomes.Count; i++)
        {
            _nextEvent = _uiEvent.Outcomes[i].NextEvent;
            GameObject go = Instantiate(_buttonPrefab, _buttonHolder);
            PopUpButton popUpButton = go.GetComponent<PopUpButton>();

            bool isInteractable = false;

            for (int j = 0; j < _uiEvent.Outcomes[i].value.Count; j++)
            {
                if (_uiEvent.Outcomes[i].value[j] < 0)
                {
                    isInteractable = CheckResource(_uiEvent.Outcomes[i].value[j], _uiEvent.Outcomes[i].uIResourceType[j]);
                    break;
                }
            }

            popUpButton.SetUpButton(_uiEvent.Outcomes[i].OutComeText, i, !isInteractable);
            popUpButtons.Add(popUpButton);
        }
    }

    public bool CheckResource(int amount, UIResourceType uIResourceType)
    {
        return ResourceManager.Instance.CheckResource(amount, uIResourceType);
    }

    public void ShowPanel()
    {
        Panel.ShowPanel();
    }

    public void HidePanel()
    {
        Panel.HidePanel();
        UIEventEnded.Invoke();
    }

    public void CleanPanel()
    {
        for (int i = 0; i < popUpButtons.Count; i++)
        {
            Destroy(popUpButtons[i].gameObject);
        }

        popUpButtons.Clear();
    }

    public void DisplayText (int index)
    {
        string text = string.Empty;

        for (int i = 0; i < _uiEvent.Outcomes[index].uIResourceType.Count; i++)
        {
            switch(_uiEvent.Outcomes[index].uIResourceType[i])
            {
                case UIResourceType.Food:
                case UIResourceType.Fuel:
                case UIResourceType.People:
                case UIResourceType.Scrap:
                    text += _uiEvent.Outcomes[index].value[i].ToString() + " " + _uiEvent.Outcomes[index].uIResourceType[i].ToString() + " ";
                    break;
            }
        }

        OutComeText.SetText(text);
        OutComeText.DisplayText();
    }

    public void HideText()
    {
        OutComeText.HideText();
    }
}
