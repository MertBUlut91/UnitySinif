using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    private GunLight gunlight;
    private Gun gun;

    private void Awake()
    {
        gunlight = GameObject.Find("Gun Light").GetComponent<GunLight>();
        gun = GameObject.Find("Gun").GetComponent<Gun>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gunlight.isClose = true;
            gun.FireBullet();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gunlight.isClose = false;
        }
    }
}
