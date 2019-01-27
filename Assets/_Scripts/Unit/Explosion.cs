using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    [SerializeField] private Sprite[] exphSprites;
    [SerializeField] SpriteRenderer rend;
    [SerializeField] private float interval = 0.2f;
    private YieldInstruction _instruction;

    private void Awake()
    {
        _instruction = new WaitForSeconds(interval);
    }

    public void DoBoom()
    {
        CombatManager.Instance.Exploded.Raise();
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        int index = 0;
        while (index < exphSprites.Length)
        {
            rend.sprite = exphSprites[index];
            index++;
            yield return _instruction;
        }
        rend.sprite = null;
        PoolingSystem.DestroyAPS(gameObject);
    }
}
