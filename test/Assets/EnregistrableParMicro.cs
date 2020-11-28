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
*/


public class EnregistrableParMicro : MonoBehaviour
{
    //sahder pour le contour (c'est pas moi qui l'ai codé)
    private Outline contour;
    private Color couleurPreSelection = Color.yellow;
    private Color couleurEnregistrement = Color.green;


    //gestion des mixers
    private AudioSource source;
    //le mixer par défaut
    private AudioMixerGroup master;



    private void Awake() {
        //ajout d'un shader outline inactif
        this.contour = gameObject.AddComponent(typeof(Outline)) as Outline;
        this.contour.OutlineWidth = 5f;
        this.contour.enabled = false;
    }


    private void Start()
    {   
        //récupère l'audiosource
        this.source = gameObject.GetComponent<AudioSource>();
        if (!this.source)
        {
            Debug.Log("le gestionnaire de mixer n'a pas trouvé d'audiosource à gérer");
            return;
        }

        //récupère le mixer master
        AudioMixer mixer = Resources.Load<AudioMixer>("Jeu");
        AudioMixerGroup[] groups = mixer.FindMatchingGroups("Master");
        this.master = groups[0];
        //par défaut on s'enregistre au mixer master
        this.source.outputAudioMixerGroup = this.master;
    }




    //méthode appelée quand un micro est à portée
    public void PreSelectionner()
    {
        this.contour.enabled = true;
        this.contour.OutlineColor = this.couleurPreSelection;
    }

    //methode appelée quand un micro est en train d'enregistrer l'objet
    //public void Enregistrer(AudioMixerGroup mixer)
    public void Enregistrer()
    {
        this.contour.enabled = true;
        this.contour.OutlineColor = this.couleurEnregistrement;

        //changement de mixer
        //this.source.outputAudioMixerGroup = mixer;
    }

    //qaudn l'objet n'est plus présélectionné
    public void SortiePreSelection()
    {
        this.contour.enabled = false;
    }

    //quand l'objet n'est plus enregistré
    public void SortieEnregistrement()
    {
        this.contour.OutlineColor = this.couleurPreSelection;
    }
}
