using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/**************************************************************************************************
BZ
//Une classe qui vient gérer tous les mixers
//Pour le moment elle ne vient gérer qu'un seul mixer, "accords"
//C'est ce manager qui s'occupe de changer le rythme en fonction du bpm par exemple
//le manager implémente EnregistrementPeriodeNoire pour pouvoir s'enregistrer auprès du metronome
*******************************************************************************************************/

public class MixerManager : MonoBehaviour
{
    //tous les groupes du mixer
    private AudioMixerGroup[] groups;


    void Start()
    {
        //récupère le mixer dans les assets
        AudioMixer mixer = Resources.Load<AudioMixer>("accords");
        //récupère tous les groupes du mixer
        this.groups = mixer.FindMatchingGroups(string.Empty);

        //enregistrement auprès du metronome
        GameObject metronome = GameObject.Find("Metronome");
        //metronome.GetComponent<Metronome>().EnregistrerPeriodeNoire(this);
    }


    //Quand la période change, tous les groupes ajustent leur cycleTime
    public void ChangementDePeriodeNoire(float periode)
    {
        foreach (AudioMixerGroup group in this.groups)
        {
            group.audioMixer.SetFloat("cycleTime", periode*2);
        }
    }

}
