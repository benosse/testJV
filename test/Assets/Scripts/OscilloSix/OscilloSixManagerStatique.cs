using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***********************************************************************
//BZ
//Un OscilloSixManagerStatique se trouve toujours dans une sousZone et n'en change jamais
//sa fréquence est décidée par sa sousZone
//sa méthode playSound joue son son
//***********************************************************************

public class OscilloSixManagerStatique : OscilloSixManager
{
    public override void Start()
    {
        //appel du start de base
        base.Start();
        

        //récupération de la sousZone et de la fréquence
        this.sousZone = gameObject.transform.parent.gameObject.GetComponent<SousZone>();
        this.SetFrequence(this.sousZone.GetFrequence());
        //Debug.Log("freqZone: " + this.sousZone.GetFrequence());

    }
}
