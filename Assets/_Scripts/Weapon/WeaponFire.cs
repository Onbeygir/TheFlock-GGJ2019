using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    [SerializeField] float fireRate;
    [SerializeField] float damage;
    [SerializeField] MuzzleFlash[] flash;
    [SerializeField] string bulletName;

    float elapsedTime = 0;
    public void FireWeapon(Transform target)
    {
        elapsedTime += Time.deltaTime;
        if (fireRate < elapsedTime)
        {
            int rand = Random.Range(0, flash.Length);
            flash[rand].DoFlash();
            target.GetComponent<Health>().UpdateHealth(-damage);
            elapsedTime = 0;
            GameObject go = PoolingSystemExtensions.InstantiateAPS(bulletName, flash[rand].transform.position, Quaternion.identity);
            Vector3 randPos = target.GetComponent<BoxCollider>().bounds.extents * Random.Range(0f,1f);
            go.GetComponent<Bullet>().
                FlyTo(target.position+randPos);
        }
    }
    public void ChangeDamage(float newDamage)
    {
        damage = newDamage;
    }
}
