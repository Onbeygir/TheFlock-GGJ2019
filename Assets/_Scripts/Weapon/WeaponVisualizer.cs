using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponVisualizer : MonoBehaviour
{
    public float[] angleList;
    

    public void SetAngle(float angle)
    {
        float diff = float.PositiveInfinity;
        int selectedIndex = -1;
        for (int i = 0; i < angleList.Length; i++)
        {
            float temp = Mathf.Abs(angle - angleList[i]);
            if (temp < diff)
            {
                diff = temp;
                selectedIndex = i;
            }
        }
        transform.rotation = Quaternion.AngleAxis(angleList[selectedIndex] ,Vector3.forward );
    }
}
