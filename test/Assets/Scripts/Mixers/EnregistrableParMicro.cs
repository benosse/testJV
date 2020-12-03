using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


/*
BZ
composant à mettre à un objet pour qu'il soit enregistrable par un micro
Ce script gère deux choses:
- les mixers de son gameobject (mixer par défaut, changement de mixer...)
-la réactivité par rapport au micro (ajoute un contour quand sélectionné par un micro...)

le script dialogue avec le script "GestionnaireMixer" de l'objet
*/


public class EnregistrableParMicro : MonoBehaviour
{
    //sahder pour le contour (c'est pas moi qui l'ai codé)
    private Outline contour;
    private Color couleurPreSelection = Color.yellow;
    private Color couleurEnregistrement = Color.green;

    private bool preSelectionEnCours = false;
    private bool enregistrementEnCours = false;


    //gestion des mixers
    private GestionnaireMixer gestionnaireMixer;



    private void Awake() {
        //ajout d'un shader outline inactif
        this.contour = gameObject.AddComponent<Outline>();
        this.contour.enabled = false;
        this.contour.OutlineWidth = 5f;
        this.contour.OutlineColor = Color.blue;
    }


    private void Start()
    {   
        this.gestionnaireMixer = gameObject.GetComponent<GestionnaireMixer>();
        
    }



    //*****************************************************************************************************
    //PRESELECTION  
    //*****************************************************************************************************
    public void PreSelectionner()
    {
        this.contour.enabled = true;    
        Debug.Log("eeeee" + this.contour.OutlineColor);
    }

    public void SortiePreSelection()
    {
        this.contour.enabled = false;

    }



    //*****************************************************************************************************
    //ENREGISTREMENT 
    //*****************************************************************************************************
    public void Enregistrer(AudioMixerGroup mixer)
    {
        this.enregistrementEnCours = true;

        this.contour.enabled = true;
        this.contour.OutlineColor = this.couleurEnregistrement;

        //mixer
        this.gestionnaireMixer.SetMixer(mixer);
    }

    public void SortieEnregistrement()
    {
        this.enregistrementEnCours = false;

        this.contour.OutlineColor = this.couleurPreSelection;
        //this.contour.enabled = false;
   

        //mixer
        this.gestionnaireMixer.resetMixerParDefaut();
    }
}
