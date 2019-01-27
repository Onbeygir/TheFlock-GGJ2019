using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CombatManager : Singleton<CombatManager>
{
    public enum GameState
    {
        OutofCombat,
        InCombat        
    }

    public GameState State = GameState.OutofCombat;
    public SO_Party PlayerParty;
    public SO_Party EnemyParty;

    public UnityEvent CombatEnded;

    public WaveFactory Factory;

    public SO_WaveData TestWave; // SILME, KULLANMIYORSAN NULL BIRAK

    public GameEvent Exploded;

    private void Awake()
    {
        PlayerParty.Init();
        EnemyParty.Init();
    }

    private void Start()
    {
        if (TestWave)
        {
            Factory.CreateWave(TestWave);
        }
    }


  
    public void StartCombat(SO_WaveData[] waves)
    {
        AudioManager.instance.StartCombatAudio();
        StartCoroutine(CombatCo(waves));
    }

    IEnumerator CombatCo(SO_WaveData[] waves)
    {
        int index = 0;
        while (index < waves.Length)
        {
            Factory.CreateWave(waves[index]);

           
            yield return new WaitForSeconds(1);

            while (EnemyParty.Vehicles.Count > 0)
                yield return null;

            index++;
        }
        OnCombatEnded();
    }

    public void OnCombatEnded()
    {
        AudioManager.instance.CombatEndAudio();
        CombatEnded.Invoke();
    }
}
