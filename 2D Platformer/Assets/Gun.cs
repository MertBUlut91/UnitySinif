using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Vector2 direction;
    private Vector2 target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletSpawnPos;
    [SerializeField] ParticleSystem muzzleEffect;

    [SerializeField] float fireRate;
    private float nextFire = 0;


    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player!=null)
        {
            target = player.transform.position;
            direction = target -(Vector2)transform.position;
            transform.right = -direction;
        }

    }
    public void FireBullet()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
    }
    public void Fire()
    {
        Instantiate(bulletPrefab, bulletSpawnPos.transform.position, bulletSpawnPos.transform.rotation);
        Instantiate(muzzleEffect, bulletSpawnPos.transform.position, Quaternion.identity);

    }
}
