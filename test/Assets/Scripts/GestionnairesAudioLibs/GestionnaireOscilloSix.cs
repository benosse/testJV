using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;

/********************************************************************************
BZ
GestionnaireOscilloSix gère l'audiolib oscilloSix de son gameobject notamment par l'intérmediaire d'enveloppes
Il implémente l'interface IAudioLibEnregistrable pour pouvoir être ciblé par un micro
Dans ce cas il met à jour l'oscillo de son gameobject et de ses clones dans les micros
*********************************************************************************/


public class GestionnaireOscilloSix : MonoBehaviour, IGestionnaireAudioLib
{
    //todo revoir le système de zones
    protected SousZone sousZone;


    //l'ocillo à gérer
    protected Hv_oscilloSix_AudioLib oscillo;
    
    //Pour chaque paramètre de l'audiolib on associe une enveloppe, et une fonction delegate (= callback)
    public GestionnaireADSR enveloppeGain;
    public GestionnaireADSR enveloppeNbHarmo;
    public GestionnaireADSR enveloppeMidFreq;

    //valeurs de l'oscillo
    [SerializeField] private float frequence;
    private float gain;
    private float glide;
    private float interpolationFreq;
    private float midFreq;
    private float nbHarmo;
    private float selectOutput;
    private float smoothGain;

    //liste de clones à mettre à jour 
    private List<Hv_oscilloSix_AudioLib> clonesOscillo;

    

    private void Awake() {
        oscillo = gameObject.GetComponent<Hv_oscilloSix_AudioLib>();
        this.clonesOscillo = new List<Hv_oscilloSix_AudioLib>();
    }



    public virtual void Start()
    {
        

        if (enveloppeGain)
        {
            enveloppeGain.EnregistrerBrut(setGain);
        }
        if (enveloppeNbHarmo)
        {
            enveloppeNbHarmo.EnregistrerBrut(SetNbHarmoniques);
        }
        if (enveloppeMidFreq)
        {
            enveloppeMidFreq.EnregistrerBrut(SetMidFreq);
        }
    }


     //*****************************************************************************************************
     //SETTERS
     //ils mettent également à jour les clones
    //*****************************************************************************************************
  
    public void setGain(float valeur)
    {
        this.gain = valeur;

        this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Gain, valeur*0.05f);

        foreach (Hv_oscilloSix_AudioLib clone in this.clonesOscillo)
        {
            clone.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Gain, valeur*0.05f);
        }
    }

    public void SetNbHarmoniques(float valeur)
    {
        this.nbHarmo = valeur;

        this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Nbharmo, valeur * 2);

        foreach (Hv_oscilloSix_AudioLib clone in this.clonesOscillo)
        {
            clone.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Nbharmo, valeur * 2);
        }
    }

    public void SetFrequence(float valeur)
    {
        this.frequence = valeur;

        this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Freqmaster, valeur );

        foreach (Hv_oscilloSix_AudioLib clone in this.clonesOscillo)
        {
            clone.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Freqmaster, valeur );
        }
    }

    public void SetMidFreq(float valeur)
    {
        this.midFreq = valeur;

        this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Midfreq, valeur);

        foreach (Hv_oscilloSix_AudioLib clone in this.clonesOscillo)
        {
            clone.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Midfreq, valeur);
        }
    }




    
    //*****************************************************************************************************
    //IMPLEMENTATION DE IAUDIOLIBENREGISTRABLE   
    //*****************************************************************************************************

    // clone l'audiolib dans l'objet enregistreur
    public void Cloner(GameObject cible)
    {
        Hv_oscilloSix_AudioLib clone = cible.AddComponent<Hv_oscilloSix_AudioLib>();

        this.clonesOscillo.Add(clone);
        clone.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Freqmaster, this.frequence);
    }

    //supprime l'audiolib de la cible
    public void Supprimer(GameObject cible)
    {
        Debug.Log("suppression");
        Destroy(cible.GetComponent<Hv_oscilloSix_AudioLib>());
    }
}

