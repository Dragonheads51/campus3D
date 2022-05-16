using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class opencloseMenu : MonoBehaviour
{

    public static bool paused;

    [SerializeField] GameObject player;
    [SerializeField] GameObject cam;

    PlayerMovement playerController;
    MouseLook mouseLook;

    private Vector3 newPos;

    void start(){
        paused = false;
        newPos = new Vector3();

        playerController = player.GetComponent<PlayerMovement>();
        mouseLook = cam.GetComponent<MouseLook>();


        playerController.isEnable =false ;
        mouseLook.isEnable = false;



       }



    void Update(){

        //Debug.Log(mouseLook.isEnable);


        if (Input.GetKeyDown(KeyCode.C)){
            if (paused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }



    public void Resume(){
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void Pause(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }




    public void askForTP(Button bouton){

        string t = bouton.GetComponentsInChildren<Text>()[0].text;

        switch (t){
            case "Amphi":
                newPos.Set(0,200,0);
                Debug.Log("Téléportation Amphy");
                break;
        }

        StartCoroutine("tp");

    }

    IEnumerator tp(){
        Debug.Log("Téléportation first");


        playerController.isEnable = false;
        mouseLook.isEnable = false;

        Debug.Log("Téléportation first");
        yield return new WaitForSeconds(1f);
        Debug.Log("Téléportation mid");
        player.transform.position = newPos;
        yield return new WaitForSeconds(1f);
        Debug.Log("Téléportation last");

        playerController.isEnable = true;
        mouseLook.isEnable = true;


    }



}
