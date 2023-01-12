using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float maxHp = 1000;
    public float currentHp = 1000;
    public int armor = 0;

    float timer;
    private float lastHP;

    [SerializeField] float invincibleTime = 0.5f;
    [HideInInspector] public Level level;
    [HideInInspector] public EuroDollars euroDollars;
    [HideInInspector] public bool isInvinsible;

    public float damageMult;
    //public float pickupRange;
    //public float healthRegen;
    //public float lifesteel;
    
    public HealthBar hpBar; 


    private void Awake()
    {
        level = GetComponent<Level>();
        euroDollars = GetComponent<EuroDollars>();
    }


    public void TakeDamage(int damage)
    {
        ApplyArmor(ref damage);

        currentHp -= damage;
    
        if(currentHp <=0)
        {
            Debug.Log("Character is dead GAME OVER");

        }
    }

 
    public void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if(damage < 0)
        {
            damage = 0;
        }

    }


    public void Heal(int health)
    {
        if(currentHp < maxHp)
        {
            currentHp += health;
            if(currentHp > maxHp)
            {
                currentHp = maxHp;
            }
            hpBar.SetState(currentHp, maxHp);
        }

    }


    private void Start()
    {
        hpBar.SetState(currentHp, maxHp);
    }
    

    private void Update()
     {
            
        if(lastHP != currentHp && isInvinsible == false)
        {
            isInvinsible = true;
            lastHP = currentHp;
            
            hpBar.SetState(currentHp, maxHp);
        }
            
        if(isInvinsible == true)
        {
            timer -= Time.deltaTime;
            if (timer < 0f){
                timer = invincibleTime;
                isInvinsible = false;
            }
            currentHp = lastHP;

            hpBar.SetState(lastHP, maxHp);
        }
     }
        
    
}
