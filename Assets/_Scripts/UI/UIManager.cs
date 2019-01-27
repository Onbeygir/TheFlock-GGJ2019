using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

[System.Serializable]
public class PopUpData
{
    public TextAsset textAsset;
}

public class UIManager : Singleton<UIManager>
{
    public List<PopUpData> popUpData;
    
    public UIPopUp UIPopUp;


    [BoxGroup("In Game UI Elements")]
    public Text PeopleText;

    [BoxGroup("In Game UI Elements")]
    public Text FoodText;

    [BoxGroup("In Game UI Elements")]
    public Text FuelText;

    [BoxGroup("In Game UI Elements")]
    public Text ScrabsText;

    public Image endscreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            endscreen.enabled = true;
    }

    public void UpdateInGameUI()
    {
        ResourceManager.Instance.UpdateUI(PeopleText, FoodText, FuelText, ScrabsText);
    }


    public void OpenPopUp(TextAsset json)
    {
        UIPopUp.CleanPanel();
        UIPopUp.AssignData(json);
        UIPopUp.Deserialize();
        UIPopUp.SetUpPopUp();
        UIPopUp.ShowPanel();
    }

    public void OpenPopUp(int index)
    {
        UIPopUp.CleanPanel();
        UIPopUp.AssignData(popUpData[index].textAsset);
        UIPopUp.Deserialize();
        UIPopUp.SetUpPopUp();
        UIPopUp.ShowPanel();
    }

    [Button(ButtonSizes.Medium)]
    public void HidePopUp()
    {
        UIPopUp.CleanPanel();
        UIPopUp.HidePanel();
    }
}
