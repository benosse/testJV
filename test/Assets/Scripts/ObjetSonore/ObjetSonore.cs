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
    
    public Enveloppe enveloppe;


    public virtual void Start()
    {
        //ou bien récupération si on le crée dans l'inspecteur
        oscillo = gameObject.GetComponent<Hv_oscilloSix_AudioLib>();

        //todo : si il y n'y  pas d'enveloppes
        enveloppe.EnregistrerObjetSonore(this);
    }

    public void SetGain(float gain)
    {
        this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Gain, gain*0.2f);
    }


    //change la fréquence de son oscillo
    public void SetFrequence(float frequence)
    {
        this.frequence = frequence;
        this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Freqmaster, frequence);
    }


}

