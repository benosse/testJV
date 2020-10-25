/*
BZ
Un objet qui gère toutes lez zones du jeu.
Elle sauvegarde dans quelle zone le joueur se trouve actuellement et commande le lancement audio des zones.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonesHandler : MonoBehaviour
{

    //La zone dans laquelle le joueur se trouve
    private GameObject activeZone;


    void Update()
    {
      //Si le joueur se trouve dans une zone, on demande à la zone de jouer son audio
      if (activeZone != null)
      {
        activeZone.GetComponent<ZoneAudio>().playSound();
      }
    }

    //change la zone active
    public void setZone(GameObject zone)
    {
      Debug.Log("handler setting the zone..." + zone.name);
      activeZone = zone;
    }

    //quitte la zone actuelle
    public void leaveZone(GameObject zone)
    {
      Debug.Log("leaving zone" + activeZone.name);
      if (activeZone == zone)
      {
        activeZone = null;
      }
    }
}
