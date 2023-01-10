using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingSwordWeapon : MonoBehaviour
{
    [SerializeField] float attackRate;
    
    PlayerMovement playerMovement;
    float timer;
    [SerializeField] GameObject swordPrefab;


    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();

    }
 
 
    void Update(){
        if(timer < attackRate){
            timer += Time.deltaTime;
            return;
        }
        timer = 0;
        SpawnSword();
    }


    private void SpawnSword(){
        GameObject thrownSword = Instantiate(swordPrefab);
        thrownSword.transform.position = transform.position;
        thrownSword.GetComponent<TrowingSwordProjectile>().SetDirection(playerMovement.lastHorizontalVector, 0f);
    }
}
