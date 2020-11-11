using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***********************************************************************
//BZ & LA
//Un OscilloSixManager  se trouve dans 1 ou zéro sousZone
//sa fréquence est décidée par sa sousZone
//sa méthode playSound joue son son
//***********************************************************************


public class OscilloSixManagerDynamique : OscilloSixManager
{


    //trigger par la sousZone quand l'OscilloSixManager rentre dedans
    public void EnterSousZone(SousZone sousZone)
    {
        //change la sousZone
        this.sousZone = sousZone;
        //change la fréquence
        this.SetFrequence(this.sousZone.GetFrequence());

        //Debug.Log("entrée dans la sousZone " + sousZone.gameObject.name);

    }


    //trigger par la sousZone quand l'OscilloSixManager en sort
    public void ExitSousZone(SousZone sousZone)
    {
        if (this.sousZone == sousZone)
        {
            //Debug.Log("sortie de la sousZone " + sousZone.gameObject.name);
            this.sousZone = null;
            this.SetFrequence(0);
        }
    }
}
