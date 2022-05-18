using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;


public class infoBatiment : MonoBehaviour
{
    public GameObject batimentSelection;

    void Start()
    {        

        string path = "Assets/infoBatiments1.json";
        string jsonString = File.ReadAllText(path);


        ListeBat lbats = new ListeBat(); 
        lbats.lBat = new List<Batiment>();

        lbats = JsonUtility.FromJson<ListeBat>(jsonString);


        // on initialise le texte de chaque batiments
 
        // On parcours la liste de lbat pour lire chaque Batiment en meme temps que l'on parcours la liste des batiment dans unity
        //  -> Changer le tag par un id et lié chaque info de bat par l'id dans le json et celui du tag  
         


        Debug.Log(batimentSelection);


        int nbBat = lbats.nbBat();
        for(int i =0;i<nbBat;i++){


            /**
            A mettre en forme HTML CSS
            **/
            string finalText = "";

            /**
            <p assez grand et en gras > Le nom du batiment <p assez grand et en gras ><pareil sans le gras>(le numéro)<pareil sans le gras>
            <pareil en gras> Description : </><p normal sans gras>La description .........Expliquer le fonctionnement des salles 
            ex bat 2 3 bat 2 = au dessus bat 3 celui apres bat 17 + salle derrire donc salle 1721 = batiment 17 et salle 21 donc 2eme etage salle une </>

            Si pas de nom 
            <p assez grand et en gras> Le numéro <p assez grand et en gras >
            
            Si pas de numéro pas les parenthese 
            **/



            
            if (lbats.lBat[i].numBat != -1 && !lbats.lBat[i].nomBat.Equals("")){
                finalText += "<style=champ>" + lbats.lBat[i].nomBat;
                finalText += "</style><style=parenthese> (" + lbats.lBat[i].numBat.ToString() + "</style>\n\n";


                




            }




            if (lbats.lBat[i].numBat != -1){
                finalText += "Numéro de bâtiments: " + lbats.lBat[i].numBat.ToString();
            }

            if (!lbats.lBat[i].nomBat.Equals("")){
            }

            finalText += "</style>";
            finalText += lbats.lBat[i].desc;


            // IF ID = CELUI DE L'AMPHIE TRAIER LE CAS SINON {  vvv  }

            // On trouve le gameobject avec le tag id i 
            GameObject batId = GameObject.FindGameObjectWithTag(lbats.lBat[i].id.ToString());
            TMP_Text text = batId.GetComponentInChildren<TMP_Text>();
            text.text = finalText;


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
    public string desc;
    public List<string> listeSalle;
}

[System.Serializable]
public class ListeBat {
    public List<Batiment> lBat;

    public int nbBat(){
        return lBat.Count;
    }

}