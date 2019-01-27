using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 _target;
    private YieldInstruction _instruction;

    private void Awake()
    {
       
    }
    
    public void FlyTo(Vector3 target)
    {
        _target = target;
        StartCoroutine(FlyToTarget());
    }

    IEnumerator FlyToTarget() //TODO zamana bagli degil, projectile hizina bagli olmasi lazim
    {
        float t = 0;
        float angle;
        Vector3 dir;
        while (t<0.95f)
        {
            if (_target == null)
            {
                PoolingSystem.DestroyAPS(gameObject);
                break;
            }
            t += Time.deltaTime;
            dir = transform.position - _target;
            angle = Mathf.Atan2(dir.z, dir.x)*Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.position = Vector3.Lerp(transform.position, _target, t);
            yield return null;
        }
        _target = Vector3.zero;
        PoolingSystem.DestroyAPS(gameObject);
    }
}
