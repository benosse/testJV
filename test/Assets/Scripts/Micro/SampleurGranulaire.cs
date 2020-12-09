using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*
BZ
hérite de la classe Micro
*/

public class SampleurGranulaire : Micro
{
    //deux mixers, un dry un wet, pour l'audio altéré et inaltéré
    private AudioMixerGroup dry;
    private AudioMixerGroup wet;

    //un snapshot en plus pour gérer la sortie dry ou wet
    private AudioMixerSnapshot dryOn;

    //est-ce qu'on joue la sortie dry ou wet
    bool dryMode = false;

    protected override void Awake()
    {
        base.Awake();
        this.dry = mixer.FindMatchingGroups("Dry")[0];
        this.wet = mixer.FindMatchingGroups("Wet")[0];

        //trois snapshots : On (=WetOn) DryOn, Off
        this.dryOn = mixer.FindSnapshot("DryOn");

    }

    protected override void Start() {
        this.audioSource.outputAudioMixerGroup = this.dry;
        this.off.TransitionTo(0f);
    }



    //*****************************************************************************************************
    //EVENEMENTS    
    //e enregistrer, c desenregistrer, j jouer
    //*****************************************************************************************************
    protected override void GestionEvenements()
    {
        if (Input.GetKeyDown("space"))
        {
            this.dryMode = !this.dryMode;

            if (this.lectureEnCours)
            {
                if (this.dryMode)
                {
                    this.dryOn.TransitionTo(this.transition);
                }
                else{
                    this.on.TransitionTo(this.transition);
                }
            }
        }

        else {
            base.GestionEvenements();
        }
    }


    public override void Enregistrer()
    {
        base.Enregistrer();

        if (this.cibleActuelle)
        {   
            //lance granulaire
            this.mixer.SetFloat("record", 1f);
            this.mixer.SetFloat("playGrains", 1f);
            Debug.Log("granulaire lancé");
        }
    }


    public override void Jouer()
    {
        if (this.lectureEnCours)
        {
            this.lectureEnCours = false;
            this.off.TransitionTo(this.transition);
        }
        else
        {
            this.lectureEnCours = true;

            if (this.dryMode)
            {
                this.dryOn.TransitionTo(this.transition);
            }
            else{
                this.on.TransitionTo(this.transition);
            }
        }
    }


    public override void Desenregistrer()
    {
        base.Desenregistrer();

        //arrete granulaire
        this.mixer.SetFloat("record", 0f);
        this.mixer.SetFloat("playGrains", 0f);

        this.dryMode = false;
    }
}
