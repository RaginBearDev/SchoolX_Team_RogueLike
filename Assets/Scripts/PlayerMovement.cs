    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public float x_axis, y_axis;
    public Transform vectorMove;
    public float speed = 10;
    
    [HideInInspector]
    public Vector3 movementVector;
    Rigidbody2D rgbd2d;

    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;

    
    void Start()
    {
        vectorMove = GetComponent<Transform>();
        rgbd2d = GetComponent<Rigidbody2D>();

        lastHorizontalVector = -1f;
        lastVerticalVector = 1f;
    }


    void FixedUpdate()
    {       
        x_axis = Input.GetAxis("Horizontal");
        y_axis = Input.GetAxis("Vertical"); 

        Vector3 moveVector = new Vector3(x_axis, y_axis, 0);
        vectorMove.Translate(moveVector * speed * Time.fixedDeltaTime);

        if(x_axis != 0){
            lastHorizontalVector = x_axis;
        }
        if(y_axis != 0){
            lastVerticalVector = y_axis;
        }
    }


}
        

