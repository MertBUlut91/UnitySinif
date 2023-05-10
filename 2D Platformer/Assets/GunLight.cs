using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLight : MonoBehaviour
{
    [SerializeField] GameObject gunLight;
    public bool isClose;

    void Update()
    {
        GunLightChange();
    }
    private void GunLightChange()
    {
        if (isClose)
        {
            gunLight.GetComponent<SpriteRenderer>().color = Color.red;
            
        }
        else
        {
            gunLight.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}
