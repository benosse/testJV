using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*
BZ
script qui gère le mixer de sortie d'une audiosource
gère aussi la possibilité d'être sampler ( = passer à un mixer sampler)
*/
public class GestionnaireMixer : MonoBehaviour
{
    private AudioSource source;
    //le mixer par défaut
    private AudioMixerGroup master;


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


    public void SetMixer(AudioMixerGroup mixer)
    {
        this.source.outputAudioMixerGroup = mixer;
    }
}
