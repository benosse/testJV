using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***********************************************************************
//BZ 
// à ajouter aux objets qui ont un gestionnaireAudioLib et une fréquence à gérer en fonction de la zone dans laquelle ils se trouvent
//***********************************************************************



public class FrequenceParZone : MonoBehaviour {
    
    private IGestionnaireAudioLib gestionnaireAudioLib;
    [SerializeField] private SousZone sousZone;

    private void Awake() {
        this.gestionnaireAudioLib = gameObject.GetComponent<IGestionnaireAudioLib>();
        this.sousZone = gameObject.transform.parent.gameObject.GetComponent<SousZone>();   
    }

     private void Start() {
         //si l'objet a une souszone comme parent on lui attribue d'office se fréquence
         if (this.sousZone)
         {
             this.gestionnaireAudioLib.SetFrequence(this.sousZone.GetFrequence());
         }
     }

     public void SetFrequence(float frequence)
     {
         this.gestionnaireAudioLib.SetFrequence(frequence);
     }



    //trigger par la sousZone quand l'objet rentre dedans
    public void EnterSousZone(SousZone sousZone)
    {
        //change la sousZone
        this.sousZone = sousZone;
        //change la fréquence de l'audiolib

        this.gestionnaireAudioLib.SetFrequence(this.sousZone.GetFrequence());

    }


    //trigger par la sousZone quand l'objet en sort
    public void ExitSousZone(SousZone sousZone)
    {
        if (this.sousZone == sousZone)
        {
            //Debug.Log("sortie de la sousZone " + sousZone.gameObject.name);
            this.sousZone = null;
            this.gestionnaireAudioLib.SetFrequence(0);
        }
    }
}
