using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

/********************************************************************************
BZ
class ObjetSonore
Un objetSonore est associé à une zone
Il a une fréquence et un manager
Cette classe est abstraite : elle n'est jamais instanciée, mais elle est héritée par ObjetSonoreStatique et ObjetSonoreDynamique
*********************************************************************************/
public abstract class ObjetSonore : MonoBehaviour
{
    [SerializeField] protected float frequence;
    protected SousZone sousZone;
    protected Hv_oscilloSix_AudioLib oscillo;
    
    //Pour chaque paramètre de l'audiolib on associe une enveloppe, et une fonction delegate (= callback)
    public Enveloppe enveloppeGain;

    public Enveloppe enveloppeNbHarmo;

    public Enveloppe enveloppeMidFreq;




    public virtual void Start()
    {
        //ou bien récupération si on le crée dans l'inspecteur
        oscillo = gameObject.GetComponent<Hv_oscilloSix_AudioLib>();


        if (enveloppeGain)
        {
            enveloppeGain.Enregistrer(setGain);
        }
        if (enveloppeNbHarmo)
        {
            enveloppeNbHarmo.Enregistrer(SetNbHarmoniques);
        }
        if (enveloppeMidFreq)
        {
            enveloppeMidFreq.Enregistrer(SetMidFreq);
        }
    }




    //Setters
    public void setGain(float valeur)
    {
        this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Gain, valeur*0.2f);
    }

    public void SetNbHarmoniques(float valeur)
    {
        this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Nbharmo, valeur*5);
    }

    public void SetFrequence(float frequence)
    {
        //enregistrement de la fréquence - utile ?
        this.frequence = frequence;
        this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Freqmaster, frequence);
    }

    public void SetMidFreq(float valeur)
    {
        this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Midfreq, 5 - valeur*5);
    }
}

