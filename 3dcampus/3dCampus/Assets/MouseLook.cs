using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 40f;
    public Transform playerBody; 
    float xRotation = 0f;

    public bool isEnable = true;


    void Start(){
        mouseSensitivity = 40f;
        isEnable = true;
        Cursor.lockState = CursorLockMode.Locked;


    }


    void Update()
    {
        if (isEnable){
            look();
        }
    }


    void look(){
        float mouseX = Input.GetAxis("Mouse X")* mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")* mouseSensitivity * Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f,90f);

        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);

        playerBody.Rotate(Vector3.up*mouseX);

    }

}
