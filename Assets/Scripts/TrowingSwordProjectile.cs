using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrowingSwordProjectile : MonoBehaviour
{
    Vector3 direction; 
    public float speed;
    public int damage = 500;
    bool hitDetected = false;


    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3(dir_x, dir_y);

        if(dir_x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = -1 * scale.x;
            transform.localScale = scale;
            direction.x = -1;
        }
        else
        {
            direction.x = 1;
        }
    }

    
    private void Update() 
    { 
        transform.position += direction * speed * Time.deltaTime;
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
            if (hitDetected)
            {
            Destroy(gameObject);
            }
        }
    } 
}
