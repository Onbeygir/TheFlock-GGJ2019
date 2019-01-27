using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] float _health;
    [SerializeField] float _maxHealth;
    public UnityEvent Destroyed;
    [SerializeField] SpriteRenderer rend;

    public bool isDead;

    private void OnEnable()
    {
        isDead = false;
    }

    public void Setup(float health, float maxhealth)
    {
        _health = health;
        _maxHealth = maxhealth;
    }

    public void UpdateHealth(float value)
    {
        _health += value;
        if (_health <= 0)
        {
            _health = 0;
            Die();
        }else if (_maxHealth < _health)
        {
            _health = _maxHealth;
        }
    }

    public void Die()
    {
        if (isDead)
            return;

        isDead = true;
        GameObject go = PoolingSystemExtensions.InstantiateAPS("Explosion",transform.position,Quaternion.identity);
        go.GetComponent<Explosion>().DoBoom();
        Destroy(gameObject);
        isDead = true;
        AudioManager.instance.ExplosionAudio();
        OnDestroyed();
       
    }

    
    
    private void OnDestroyed()
    {
        Destroyed.Invoke();
    }
}
