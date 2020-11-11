using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Env0: Enveloppe, EnregistrementStaticMesure, EnregistrementPeriodeNoire
{

    public override void Start()
    {

        base.Start();

        this.metronome.EnregistrerStaticMesure((EnregistrementStaticMesure)this);
        this.metronome.EnregistrerPeriodeNoire((EnregistrementPeriodeNoire)this);


        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Moderesetadsr, 0f);
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Seuiladsr, 0.2f);

        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Smoothenvadsr, 500f);

        
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Formeattackadsr,0f);
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Formedecayadsr, 1f);
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Formereleaseadsr, 2f);
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Smoothreset, 0f);
  
    }


    public void ChangementDeStaticMesure(int staticMesure)
    {
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Triggeradsr, 1f); 
         
    }

    /*public void ChangementDeStaticNoire(int staticNoire)
    {
        //1Debug.Log("trigger asd");
         this.enveloppe.SetFloatParameter(Hv_asd_AudioLib.Parameter.Triggerasd, 1f); 
    }*/

    public void ChangementDePeriodeNoire(float periodeNoire) 
    {
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Attacktimeadsr, periodeNoire/2);
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Decaytimeadsr,periodeNoire);
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Sustaintimeadsr, periodeNoire/2);
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Releasetimeadsr, periodeNoire*2);

        //Debug.Log("nouvelle per noire : " + periodeNoire);
    }


}
