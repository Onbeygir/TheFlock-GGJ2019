using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class PopUpDebug
{
    public TextAsset PopUpData;
}

public class UIDebugManager : Singleton<UIDebugManager>
{
    [LabelText("PopUp")]
    public List<PopUpDebug> popUpDebugs;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            OpenPopUp(1);
    }

    public UIPopUp UIPopUp;
    [Button(ButtonSizes.Medium)]
    public void OpenPopUp(int dataIndex)
    {
        UIPopUp.CleanPanel();
        UIPopUp.AssignData(popUpDebugs[dataIndex].PopUpData);
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
