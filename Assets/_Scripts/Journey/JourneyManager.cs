using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class JourneyManager : MonoBehaviour
{
    [BoxGroup("Data")]
    [InlineEditor(InlineEditorModes.GUIOnly)]
    public SO_JourneyData JourneyData;

    public int index;


    public void StartJourney()
    {
        StartCoroutine(JourneyCo());
    }

    IEnumerator JourneyCo()
    {
        Time.timeScale = 1;

        if (index > JourneyData.JourneyPoints.Length)
        {
            //GameOver()
            yield break;
        }

        yield return new WaitForSeconds(JourneyData.JourneyPoints[index].timeUntilEvent);

       

        SO_EncounterData tempEnCounter = JourneyData.JourneyPoints[index] as SO_EncounterData;
        if (tempEnCounter != null)
        {
            CombatManager.Instance.StartCombat(tempEnCounter.Waves);
        }

        
        SO_JourneyEvent tempEvent = JourneyData.JourneyPoints[index] as SO_JourneyEvent;

        if (tempEvent != null)
        {
            Time.timeScale = 0;
            UIManager.Instance.OpenPopUp(tempEvent.JourneyJSON);
        }
        index++;
    }
}
