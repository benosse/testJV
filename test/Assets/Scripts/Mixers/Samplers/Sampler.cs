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
    private AudioMixerGroup samplerMixer;

    public string nom;

    //l'objet qu'on veut sampler
    [SerializeField]
    private GestionnaireMixer source;

    private void Awake()
    {
        //récupération du mixer
        AudioMixer mixer = Resources.Load<AudioMixer>("Jeu");
        AudioMixerGroup[] groups = mixer.FindMatchingGroups(this.nom);

        if (groups.Length > 0)
        {
            this.samplerMixer = groups[0];
        }
        else
        {
            Debug.Log("groupe " + this.nom + " non trouvé");
        }
    }

    //simulation d'un enregistrement
    private void Update()
    {
        if (Input.GetKeyDown("space") && this.samplerMixer)
        {
            //récupération de la source
            this.source =
                GameObject
                    .FindGameObjectsWithTag("ASampler")[0]
                    .GetComponent<GestionnaireMixer>();

            //lancement de l'enregistrement
            this.source.SetMixer(this.samplerMixer);
        }
    }
}
