using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

/********************************************************************************
BZ
class GestionnaireOscilloSix
Un GestionnaireOscilloSix est associé à une zone
Il a une fréquence et un manager
Cette classe est abstraite : elle n'est jamais instanciée, mais elle est héritée par GestionnaireOscilloSixStatique et GestionnaireOscilloSixDynamique


BZ et Nico
l'oscillo route son outpu soit vers master, soit vers un sampleur
*********************************************************************************/


public abstract class GestionnaireOscilloSix : MonoBehaviour
{
    [SerializeField] protected float frequence;
    protected SousZone sousZone;
    protected Hv_oscilloSix_AudioLib oscillo;
    
    //Pour chaque paramètre de l'audiolib on associe une enveloppe, et une fonction delegate (= callback)
    public GestionnaireADSR enveloppeGain;
    public GestionnaireADSR enveloppeNbHarmo;
    public GestionnaireADSR enveloppeMidFreq;

    

    private void Awake() {
        oscillo = gameObject.GetComponent<Hv_oscilloSix_AudioLib>();
    }



    public virtual void Start()
    {
        //ou bien récupération si on le crée dans l'inspecteur
        
        this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Smoothgain, 10f);


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


    //Setters
    public void setGain(float valeur)
    {
        this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Gain, valeur*0.05f);
    }

    public void SetNbHarmoniques(float valeur)
    {
        this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Nbharmo, valeur * 2);
    }

    public void SetFrequence(float frequence)
    {
        //enregistrement de la fréquence - utile ?
        this.frequence = frequence;
        this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Freqmaster, frequence );
    }

    public void SetMidFreq(float valeur)
    {
        this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Midfreq, valeur);
    }
}
