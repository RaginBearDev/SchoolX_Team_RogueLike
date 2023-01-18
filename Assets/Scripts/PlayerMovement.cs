using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
        public Transform vectorMove;
    public float speed = 10;
    public  Camera cam;
    Vector2 mousePos;
    
    [HideInInspector]
    public Vector2 movementVector;
    public Vector2 movement;
    public Rigidbody2D rgbd2d;

    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;

    
    void Start()
    {
        vectorMove = GetComponent<Transform>();

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
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rgbd2d.rotation = angle;

        if(movement.x != 0){
            lastHorizontalVector = movement.x;
        }
        if(movement.y != 0){
            lastVerticalVector = movement.y;
        }
    }
}