using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public MeshRenderer rend;
    public Sprite sprite;
    public float _speed;
    public Vector2 offset;

    public void Move(float speed)
    {

        if (rend != null)
        {
            float x = (Time.deltaTime * _speed/10*speed);
            offset += new Vector2(x, 0);
            rend.sharedMaterial.SetTextureOffset("_MainTex", offset);
        }
    }
}
