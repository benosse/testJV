/*
BZ
Gestion des collisions au sein d'une zone.
On repère quand le joueur entre et sort de la zone.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCollision : MonoBehaviour
{
    // le gestionnaire de zone commun à toutes les zones
    public GameObject handler;

    //le joueur entre
    private void OnTriggerEnter(Collider other)
    {
        handler.GetComponent<ZonesHandler>().setZone(this.gameObject);
    }

    //le joueur sort
    private void OnTriggerExit(Collider other)
    {
      handler.GetComponent<ZonesHandler>().leaveZone(this.gameObject);
    }
}
