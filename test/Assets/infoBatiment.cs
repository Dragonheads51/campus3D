using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NewBehaviourScript : MonoBehaviour
{
    private string jsonString;
    public GameObject batimentSelection;
    public ListeBat lbats; 

    void Start()
    {

        string path = "Assets/ScriptBatiment/readJson.cs";
        jsonString = File.ReadAllText(path);

        lbats = JsonUtility.FromJson<ListeBat>(jsonString);


        // on initialise le texte de chaque batiments
 
        // On parcours la liste de lbat pour lire chaque Batiment en meme temps que l'on parcours la liste des batiment dans unity
        //  -> Changer le tag par un id et lié chaque info de bat par l'id dans le json et celui du tag  
         

        int nbBat = lbats.nbBat();
        for(int i =0;i<nbBat;i++){
            
            Debug.Log(lbats.lBat[i]);


        }



    }


    void Update(){

        // foreach selon la distance on affiche pour chaque batiment 


    }



}



[System.Serializable]
public class Batiment{

    public int id;
    public int numBat;
    public string nomBat;
    public List<string> listeSalle;
}

[System.Serializable]
public class ListeBat {
    public List<Batiment> lBat;

    public int nbBat(){
        return lBat.Count;
    }

}