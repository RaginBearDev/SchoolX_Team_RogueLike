using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GunObject : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    public GameObject droppedGunPrefab;

    [SerializeField] float bulletForce = 20f;
    [SerializeField] float fireRate = 1f;
    public int magazineSize;
    public int bulletRemaining = 12;
    [SerializeField] float reloadDuration = 1f;
    private float shootingTimer;
    private float reloadTimer;
    private bool isReloading = false;
    [HideInInspector] public bool isRightHand;
    public int gunID;



    void Start()
    {
        bulletRemaining = magazineSize;
        //ammunitionUI = GameObject.Find( "AmmunitionUI" ).GetComponentInParent<AmmunitionUI>();
    }
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && bulletRemaining > 0)
        {
            Shoot();
            return;
        }
        if (Input.GetButton("Fire1") && bulletRemaining > 0)
        {
            if (shootingTimer < fireRate)
            {
                shootingTimer += Time.deltaTime;
                return;
            }
            shootingTimer = 0;
            Shoot();
        }
        if (Input.GetKey(KeyCode.R) || isReloading)
        {
            isReloading = true;

            if(reloadTimer < reloadDuration)
            {
                reloadTimer += Time.deltaTime;
                return;
            }
            reloadTimer = 0;
            isReloading = false;
            Reload();
        } 
    }


    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        bulletRemaining -= 1;
    }


    void Reload()
    {
        bulletRemaining = magazineSize;
    }

}