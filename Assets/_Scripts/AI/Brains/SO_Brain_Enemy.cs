using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Brain_Enemy", menuName = "AI/Enemy Brain")]
public class SO_Brain_Enemy : SO_Brain
{
    public override Vector3 DoThinking(AIController ctrl)
    {
        var temp = CombatManager.Instance.PlayerParty.GetClosestVehicle(ctrl.transform.position);
        if (temp)
        {
            int randomWeaponIndex = Random.Range(0, ctrl.Weapons.Length);
            Vector3 offset = ctrl.Weapons[randomWeaponIndex].WeaponDirection;

            return temp.transform.position + offset;
        }
        else
        {
            return ctrl.transform.position;
        }
    }
}
