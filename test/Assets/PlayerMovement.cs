using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed;
    public float gravity = -20f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
  
    Vector3 velocity;
    bool isGrounded;
    public bool fly;

    public bool isEnable = true;



    void start(){
        isEnable = true;
        fly = false;
        //Cursor.visible = true;



    }

    void Update()
    {
        if (isEnable){
            playerMovement();           
        }
    }


    void playerMovement(){

        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance, groundMask);
        if ((isGrounded && velocity.y < 0) || fly){
            velocity.y = -2f;
        }

        if (Input.GetKey(KeyCode.Space)){
            fly = true;
        }
        else if(Input.GetKey(KeyCode.LeftShift)){
            fly = false;
        }



        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = 0;
        if (fly){
            if (Input.GetKey(KeyCode.Space)){
                y=1;
            }
            else if(Input.GetKey(KeyCode.LeftShift)){
                y = -1;
            }
        }

        Vector3 move = transform.right * x + transform.forward *z+ transform.up*y;


        controller.Move(move*speed*Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        
        if (!fly){
            controller.Move(velocity* Time.deltaTime);
        }
    }

}
