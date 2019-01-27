using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    public Paralax[] layers;
    [Range(0,1)]
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Accelarate(1));
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var layer in layers)
        {
            layer.Move(speed);
        }
        //speed = Mathf.Lerp(0, 1, Time.time/10);
        
    }

    IEnumerator Accelarate(float targetSp)
    {
        float t = 0f;
        float acceleration = 10f;
        while(t < 1f){
            t += Time.unscaledDeltaTime/acceleration;
            speed = Mathf.Lerp(speed, targetSp, t);
            yield return null;
        }
    }
}
