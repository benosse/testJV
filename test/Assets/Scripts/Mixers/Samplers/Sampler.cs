using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*
BZ
script qui gère les sampleurs, des mixers particuliers qui permettent d'enregistrer des audiosoruces
*/
public class Sampler : MonoBehaviour
{
    [SerializeField]
    private AudioMixer samplerMixer;
    private AudioMixerGroup master;

    public string nom;

    //l'objet qu'on veut sampler
    [SerializeField]
    private GestionnaireMixer source;

    private void Awake()
    {
        //récupération du mixer
        this.samplerMixer = Resources.Load<AudioMixer>(this.nom);
        if (!this.samplerMixer)
        {
            Debug.Log("mixer "+ this.nom + " non trouvé");
        }
        else
        {
            //récupération de l'audiogroup master du mixer
            this.master = this.samplerMixer.FindMatchingGroups("Master")[0];
        }
    }

    //enregistre la source en parametre
    public void Enregistrer(GestionnaireMixer source)
    {
        this.source = source;
        this.source.SetMixer(this.master);

        this.samplerMixer.SetFloat("record", 1f);
    }

    public void ArreterEnregistrement()
    {
        if (this.source)
        {
            this.source.resetMixerParDefaut();
            this.source = null;

            this.samplerMixer.SetFloat("record", 0f);
        }
    }

}
