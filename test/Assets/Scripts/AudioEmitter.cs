/*
BZ
Un script à attacher à tous les objets qui émettent un son
*/

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEmitter : MonoBehaviour
{

    //la zone de l'objet
    private GameObject zone;
    //le joueur (pour mesurer la distance)
    private GameObject player;

    public string degre;


    void Start()
    {
        zone = this.transform.parent.gameObject;
        player = GameObject.Find("Player");
    }

    //joue le son de l'objet en fonction de la distance par raport au joueur
    public void playAudio()
    {
      float distance = Vector3.Distance(this.transform.position, player.transform.position);
      Debug.Log("playing audio of object at degre " + degre + " distance: " + distance);
    }
}
