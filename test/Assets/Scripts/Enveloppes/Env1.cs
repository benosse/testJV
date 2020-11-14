using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Env1 : Enveloppe, EnregistrementStaticNoire, EnregistrementPeriodeNoire 
{
    
    public override void Start()
    {
        // appel de la méthode Start de la classe parent
        base.Start();

    
        //this.metronome.EnregistrerStaticNoire((EnregistrementStaticNoire)this);
        //this.metronome.EnregistrerPeriodeNoire((EnregistrementPeriodeNoire)this);
    }


    public void ChangementDeStaticNoire(int staticNoire)
    {
        //Debug.Log("trigger asd");
         this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Triggeradsr, 1f); 
    }



    public void ChangementDePeriodeNoire(float periodeNoire) 
    {

        //Debug.Log("nouvelle per noire : " + periodeNoire);

        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Attacktimeadsr, periodeNoire * 1/6);
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Decaytimeadsr, periodeNoire * (float) 0.5/6);
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Sustaintimeadsr, periodeNoire * (float)2.5/6);
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Releasetimeadsr, periodeNoire * (float)2/6);
    }




}
