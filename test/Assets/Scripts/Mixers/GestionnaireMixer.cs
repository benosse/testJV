using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*
BZ
script qui gère le mixer de sortie d'une audiosource
09/12/20 : TODO finalement il est pas très utilisé ce script, sûrement à enlever dans le futur
*/
public class GestionnaireMixer : MonoBehaviour
{
    private AudioSource source;
    //le mixer par défaut
    private AudioMixerGroup mixerParDefaut;
    //le mixer actuel (si il se fait enregistrer par exemple)
    [SerializeField] private AudioMixerGroup mixerActuel;


    private void Start()
    {
        //récupère l'audiosource
        this.source = gameObject.GetComponent<AudioSource>();
        if (!this.source)
        {
            Debug.Log("le gestionnaire de mixer n'a pas trouvé d'audiosource à gérer");
            return;
        }

        //récupère le mixer mixerParDefaut
        AudioMixer mixer = Resources.Load<AudioMixer>("Jeu");
        AudioMixerGroup[] groups = mixer.FindMatchingGroups("SonsDuJeu");
        this.mixerParDefaut = groups[0];

        //par défaut on s'enregistre au mixerParDefaut
        this.source.outputAudioMixerGroup = this.mixerParDefaut;
        this.mixerActuel = this.mixerParDefaut;
    }


    //méthode qui permet de changer le mixer de l'objet
    //à appeler par un micro par exemple
    public void SetMixer(AudioMixerGroup mixer)
    {
        this.mixerActuel = mixer;
        this.source.outputAudioMixerGroup = mixer;
    }

    //remet le mixer de l'objet à son mixer par défaut
    public void resetMixerParDefaut()
    {
        this.mixerActuel = this.mixerParDefaut;
        this.source.outputAudioMixerGroup = this.mixerParDefaut;
    }
}
