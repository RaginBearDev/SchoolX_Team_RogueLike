using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetDestination;
    private Rigidbody2D rgbd2d;
    [SerializeField] GameObject targetGameobject;
    [SerializeField] Character targetCharacter;

    [SerializeField] float speed = 10.0f;
    [SerializeField] int hp = 1000;
    [SerializeField] int damage = 10;
    [SerializeField] int exp_reward = 500;


    void Start() 
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        targetGameobject = targetDestination.gameObject;
        if (targetDestination == null) 
        {
            if (GameObject.FindWithTag ("Player")!=null)
            {
                targetDestination = GameObject.FindWithTag ("Player").GetComponent<Transform>();
            }
        }
    }


    public void SetTarget(GameObject target)
    {
        targetGameobject = target;
        targetDestination = target.transform;
    }

    
    private void FixedUpdate()
    {
        Vector3 direction =  (targetDestination.position - transform.position).normalized;
        rgbd2d.velocity = direction * speed * Time.fixedDeltaTime;
    }


    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject == targetGameobject)
        {
            Attack();
        }
    
    }


    private void OnCollisionStay2D(Collision2D collision) 
    { 
        if(collision.gameObject == targetGameobject)
        {
            Attack();
        }
    }


    private void Attack()
    {
        if(targetCharacter == null)
        {
            targetCharacter = targetGameobject.GetComponent<Character>();
        }
        targetCharacter.TakeDamage(damage);
    }


    public void TakeDamage(int damage)
    { 
        hp -= damage;
        if(hp <=0)
        {
            targetGameobject.GetComponent<Level>().AddExperience(exp_reward);
            Destroy(gameObject);
        }
    }
}

