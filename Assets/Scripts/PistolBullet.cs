using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    
    [SerializeField] GameObject hitEffect;
    [SerializeField] float hitEffectTime;
    [SerializeField] int damage = 250;
    bool hitDetected = false;

    private void Update() 
    {
        if(Time.frameCount % 6 == 0 )
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.7f);
            foreach(Collider2D c in hit){
                Enemy enemy = c.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    hitDetected = true;
                    break;
                }
            }
            if(hitDetected)
            {
            Destroy(gameObject);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, hitEffectTime);
            }
            else
            {
                Destroy(gameObject, 2f);
            }
        }
    }
}