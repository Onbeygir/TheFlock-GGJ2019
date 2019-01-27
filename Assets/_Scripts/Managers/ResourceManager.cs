using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;

public class ResourceManager : Singleton<ResourceManager>
{
    //[ValueDropdown("GetAllScriptableObjects", IsUniqueList = true, DropdownTitle = "Select Resource Data", DrawDropdownForListElements = false, ExcludeExistingValuesInList = true)]
    [BoxGroup("Data")]
    [InlineEditor(InlineEditorModes.GUIAndHeader)]
    public SO_ResourceData ResourceData;

    #region RunTime Data
    [BoxGroup("Runtime Data")]
    [MinValue(0), MaxValue(30)]
    [ProgressBar(0, "MaxPeople")]
    [ReadOnly]
    public int People;

    [BoxGroup("Runtime Data")]
    [MinValue(0), MaxValue(30)]
    [ProgressBar(0, "MaxScrap")]
    [ReadOnly]
    public int Scrap;

    [BoxGroup("Runtime Data")]
    [MinValue(0), MaxValue(30)]
    [ProgressBar(0, "MaxFuel")]
    [ReadOnly]
    public int Fuel;

    [BoxGroup("Runtime Data")]
    [MinValue(0), MaxValue(30)]
    [ProgressBar(0, "MaxFood")]
    [ReadOnly]
    public int Food;
    #endregion

    [BoxGroup("Max Resources Count")]
    [PropertyRange(1, 50)]
    public int MaxPeople;
    [BoxGroup("Max Resources Count")]
    [PropertyRange(1, 999)]
    public int MaxScrap;
    [BoxGroup("Max Resources Count")]
    [PropertyRange(1, 999)]
    public int MaxFuel;
    [BoxGroup("Max Resources Count")]
    [PropertyRange(1, 999)]
    public int MaxFood;

    private void Start()
    {
        SetResources();
    }

    private void OnEnable()
    {
        EventManager.OnUpdateResource += UpdateResource;
    }

    private void OnDisable()
    {
        EventManager.OnUpdateResource -= UpdateResource;
    }

    [Button(ButtonSizes.Medium)]
    public void UpdateResource(int amount, UIResourceType uIResourceType)
    {
        switch (uIResourceType)
        {
            case UIResourceType.People:
                People = CulcalateResource(People, amount, MaxPeople);
                break;
            case UIResourceType.Scrap:
                Scrap = CulcalateResource(Scrap, amount, MaxScrap);
                break;
            case UIResourceType.Fuel:
                Fuel = CulcalateResource(Fuel, amount, MaxFuel);
                break;
            case UIResourceType.Food:
                Food = CulcalateResource(Food, amount, MaxFood);
                break;
            case UIResourceType.Light:
            case UIResourceType.Medium:
            case UIResourceType.Heavy:
            case UIResourceType.Repair:
                CombatManager.Instance.PlayerParty.CreateVehicle(uIResourceType);
                break;
        }

        UIManager.Instance.UpdateInGameUI();
    }

    int CulcalateResource(int value, int amount, int max)
    {
        value += amount;

        if (value >= max)
            value = max;

        if (value < 0)
            value = 0;

        return value;
    }

    public bool CheckResource(int amount, UIResourceType uIResourceType)
    {
        switch (uIResourceType)
        {
            case UIResourceType.People:
                if (Mathf.Abs(amount) < People)
                    return false;
                else return true;

            case UIResourceType.Scrap:
                if (Mathf.Abs(amount) < Scrap)
                    return false;
                else return true;
            case UIResourceType.Fuel:
                if (Mathf.Abs(amount) < Fuel)
                    return false;
                else return true;
            case UIResourceType.Food:
                if (Mathf.Abs(amount) < Food)
                    return false;
                else return true;
        }

        return true;
    }

    public void UpdateUI(UnityEngine.UI.Text people, UnityEngine.UI.Text food, UnityEngine.UI.Text fuel, UnityEngine.UI.Text scrabs)
    {
        people.text = People.ToString() + "/" + MaxPeople.ToString();
        food.text = Food.ToString() + "/" + MaxFood.ToString();
        fuel.text = Fuel.ToString() + "/" + MaxFuel.ToString();
        scrabs.text = Scrap.ToString() + "/" + MaxScrap.ToString();
    }

    void SetResources()
    {
        People = ResourceData.People;
        Scrap = ResourceData.Scrap;
        Fuel = ResourceData.Fuel;
        Food = ResourceData.Food;
    }

    [Button(ButtonSizes.Medium)]
    void ResetAll()
    {
        People = 0;
        Scrap = 0;
        Fuel = 0;
        Food = 0;
    }
}
