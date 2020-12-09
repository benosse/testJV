using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


/*
BZ
composant à mettre à un objet pour qu'il soit enregistrable par un micro
Ce script gère deux choses:
-la réactivité par rapport au micro (ajoute un contour quand sélectionné par un micro...)
-la copie de l'audiolib lors de l'enregistrement
*/


public class EnregistrableParMicro : MonoBehaviour
{
    //sahder pour le contour (c'est pas moi qui l'ai codé)
    private Outline contour;
    private Color couleurPreSelection = Color.yellow;
    private Color couleurEnregistrement = Color.green;

    private bool enregistrementEnCours = false;


    //gestion des mixers
    private GestionnaireMixer gestionnaireMixer;

    //gestion de l'audioLib à copier
    private IGestionnaireAudioLib audioLib;



    private void Awake() {
        //ajout d'un shader outline inactif
        this.contour = gameObject.AddComponent<Outline>();
        this.contour.enabled = false;
        this.contour.OutlineWidth = 5f;

    }


    private void Start()
    {   
        this.gestionnaireMixer = gameObject.GetComponent<GestionnaireMixer>();
        this.audioLib = gameObject.GetComponent<IGestionnaireAudioLib>();
    }



    //*****************************************************************************************************
    //PRESELECTION  
    //*****************************************************************************************************
    public void PreSelectionner()
    {
        this.contour.enabled = true;    
        if (!this.enregistrementEnCours)
        {
            this.contour.OutlineColor = this.couleurPreSelection;
        }
        else {
            this.contour.OutlineColor = this.couleurEnregistrement;
        }
    }

    public void SortiePreSelection()
    {
        this.contour.enabled = false;
    }



    //*****************************************************************************************************
    //ENREGISTREMENT 
    //*****************************************************************************************************
    public void Enregistrer(GameObject enregistreur)
    {
        this.enregistrementEnCours = true;

        //change apparence de l'objet enregistré
        this.contour.enabled = true;
        this.contour.OutlineColor = this.couleurEnregistrement;

        //copie l'audiolib dans le micro
        this.audioLib.Cloner(enregistreur);
    }


    public void SortieEnregistrement(GameObject enregistreur)
    {
        this.enregistrementEnCours = false;

        //supprime l'audiolib dans le micro
        this.audioLib.Supprimer(enregistreur);

    }


    public AudioSource GetAudioSource()
    {
        return gameObject.GetComponent<AudioSource>();
    }
}
