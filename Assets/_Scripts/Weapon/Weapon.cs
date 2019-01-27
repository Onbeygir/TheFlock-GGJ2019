using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class Weapon : MonoBehaviour
{
    public WeaponFire wpFire;
    public WeaponEffect wpEffect;
    public WeaponVisualizer wpVisualizer;

    public Transform target;
    public float range = 5f;

    public Faction AIFaction;

    public Vector3 WeaponDirection = Vector3.zero;
    public float WeaponFireArcInDegrees = 10f;

    public float FSMTickInterval = 0.32f;
    private bool _running = false;
    private YieldInstruction _instruction;

    private void Awake()
    {
        _instruction = new WaitForSeconds(FSMTickInterval);
    }

    public void StartWeapon()
    {
        if(!_running)
            StartCoroutine(WeaponFSM());
    }

    public void ChangeDamage(float newDamage)
    {
        wpFire.ChangeDamage(newDamage);
    }

    private IEnumerator WeaponFSM()
    {
        _running = true;
        while (_running)
        {
            LookAtTarget();

            UpdateTarget();
            yield return _instruction;
        }
    }

    
    void LookAtTarget()
    {
        if (target != null)
        {
            var diff = target.position - transform.position;
            float angle = (Mathf.Atan2(diff.z, diff.x)*Mathf.Rad2Deg);
            wpVisualizer.SetAngle(angle);
        }
    }

    [Button(ButtonSizes.Medium)]
    public void Fire()
    {
        wpFire.FireWeapon(target);
        AudioManager.instance.GunshoutAudio();
    }

    //public Vector3 GetClosestPoint(UnityEntity entity)
    //{
    //    float dx = transform.position.x - entity.transform.position.x;
    //    float expectedZ = Mathf.Cos(WeaponFireArcInDegrees) * dx;
    //    float dz = transform.position.z - entity.transform.position.z;

    //    if(Mathf.Abs(dz) - Mathf.Abs(expectedZ) > 0f)
    //    {

    //    }

    //}

    void UpdateTarget()
    {
        List<AIController> enemies = CacheEnemies();
        float shortestDistance = Mathf.Infinity;
        AIController nearestEnemy = null;
        foreach (AIController enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                if(!enemy.GetComponent<Health>().isDead)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            //nearestEnemy.TargetPosition = transform.localPosition;
            target = nearestEnemy.transform;
            Fire();
        }
        else
        {
            target = null;
        }
    }

    private List<AIController> CacheEnemies()
    {
        switch (AIFaction)
        {
            case Faction.Player:
                return CombatManager.Instance.EnemyParty.Vehicles;
                
            case Faction.Raider:
                return CombatManager.Instance.PlayerParty.Vehicles;                
            default:
                break;
        }
        return null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
