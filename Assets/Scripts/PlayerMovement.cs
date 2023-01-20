using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public float speed = 10;
    public  Camera cam;
    
    MainCharacterAnimationController animate;
    Transform vectorMove;

    [HideInInspector]
    public Vector2 movementVector;
    public Vector2 movement;
    public Vector2 mousePos;
    public Rigidbody2D rgbd2d;

    [HideInInspector]
    public float lastHorizontalVector;
    public float lastVerticalVector;
    
    void Start()
    {
        vectorMove = GetComponent<Transform>();
        animate = GetComponent<MainCharacterAnimationController>();

        lastHorizontalVector = -1f;
        lastVerticalVector = 1f;
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);     
    }

    void FixedUpdate()
    {       
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical"); 
        
        vectorMove.Translate(movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rgbd2d.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 0f;
        rgbd2d.rotation = angle;
        
        if (movement.x == 0 && movement.y == 0) {
            animate.walking = false;
        } else {
            animate.walking = true;
        }
        
        if(movement.x != 0){
            lastHorizontalVector = movement.x;
        }
        
        if(movement.y != 0){
            lastVerticalVector = movement.y;
        }
        
    }
}