using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunObject : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    public GameObject droppedGunPrefab;

    [SerializeField] float bulletForce = 20f;
    [SerializeField] float fireRate = 1f;
    float timer;

    void Update()
    {

        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
            return;
        }
        if(Input.GetButton("Fire1"))
        {
            if(timer < fireRate)
            {
                timer += Time.deltaTime;
                return;
            }
            timer = 0;
            Shoot();
        }
    }


    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}