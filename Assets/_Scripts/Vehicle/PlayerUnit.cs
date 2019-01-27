using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : UnityEntity
{
    public SO_PlayerVehicleData Data;
    public GameObject SelectionIcon;
    private Health _health;
    private bool _initialized = false;
    private void Awake()
    {

        ToggleSelectionIcon(false);
        _health = GetComponent<Health>();
    }

    private void Start()
    {
        if (Data != null && _health != null)
        {
            _health.Setup(Data.MaxHealth, Data.MaxHealth);
        }
    }
    private void OnEnable()
    {
        Debug.Log("Player subbed! " + name);
        CombatManager.Instance.PlayerParty.SubscribeVehicle(GetComponent<AIController>());
    }
    

    private void OnDisable()
    {
        Debug.Log("Player unsubbed! " + name);
        if (CombatManager.Instance)
            CombatManager.Instance.PlayerParty.UnsubscribeVehicle(GetComponent<AIController>());
    }

    public void Select()
    {

        ToggleSelectionIcon(true);
        PlayerInput.Instance.SelectUnit(this);
        
        if(CombatManager.Instance.State == CombatManager.GameState.OutofCombat)
        {
            //todo toggle ui upgrade/repair
        }
    }

    public void OnDeselect()
    {
        ToggleSelectionIcon(false);
    }
    
    private void ToggleSelectionIcon(bool toggle)
    {
        if (SelectionIcon)
        {
            SelectionIcon.SetActive(toggle);
        }
    }
}
