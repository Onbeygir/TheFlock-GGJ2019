using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class MuzzleFlash : MonoBehaviour
{
    public bool _flashing = false;
    [SerializeField] private Sprite[] flashSprites;
    [SerializeField] SpriteRenderer rend;
    [SerializeField] private float interval=0.2f;
    private YieldInstruction _instruction;

    private void Awake()
    {
        _instruction = new WaitForSeconds(interval);
    }

    [Button(ButtonSizes.Medium)]
    public void DoFlash()
    {
        if(!_flashing)
            StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        _flashing = true;
        int index = 0;
        while (index < flashSprites.Length)
        {
            rend.sprite =flashSprites[index];
            index++;
            yield return _instruction;
        }
        _flashing = false;
        rend.sprite = null;
    }
}
