/*
BZ
Un script qui gère l'itégralité du son au sein d'une zone
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneAudio : MonoBehaviour
{
    //l'accord de la zone
    public string accord;
    //la zone
    private GameObject zone;
    //les objets de la zone
    private List<AudioEmitter> audioEmitters = new List<AudioEmitter>();

    void Start()
    {
        //récupère la zone
        zone = this.gameObject;

        //récupère tous les audioEmitters de la zone
        //TODO : verifier que les objets ont bien un script AudioEmitter
        for (int i = 0; i < zone.transform.childCount; i++)
        {
            audioEmitters.Add(zone.transform.GetChild(i).GetComponent<AudioEmitter>());
        }
    }


    //joue l'accord ambiant
    //joue tous les audioEmitters présenst dans la zone
    public void playSound() {

      Debug.Log("playing sound of" + this.gameObject.name);
      Debug.Log("accord: " + this.accord);
      foreach (var audioEmitter in audioEmitters)
      {
          audioEmitter.playAudio();
      }
    }
}
