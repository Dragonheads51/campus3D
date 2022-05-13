using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using System.IO;

public class batCresticScript : MonoBehaviour
{
    
    public TMP_Text texteTMP;
    public Transform plane;
    public Transform target;


    void Start()
    {

        string path = "Assets/ScriptBatiment/texte/test";

        StreamReader reader = new StreamReader(path);

        texteTMP.text = reader.ReadToEnd();

        reader.Close();

    }


    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - target.position);

        float distance = Vector3.Distance(texteTMP.transform.position, target.transform.position);
        if (distance >= 500 ){
            texteTMP.gameObject.GetComponent<Renderer>().enabled = false;
            plane.GetComponent<Renderer>().enabled = false;
        }

        else if (distance < 500){
            texteTMP.gameObject.GetComponent<Renderer>().enabled = true;
            plane.GetComponent<Renderer>().enabled = true;

        }
    }
}
