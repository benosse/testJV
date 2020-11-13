using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnveloppeTroupeau : Enveloppe, EnregistrementStaticMesure, EnregistrementPeriodeNoire 
{
    
    public override void Start()
    {
        // appel de la méthode Start de la classe parent
        base.Start();

    
        this.metronome.EnregistrerStaticMesure((EnregistrementStaticMesure)this);
        this.metronome.EnregistrerPeriodeNoire((EnregistrementPeriodeNoire)this);
    }


    public void ChangementDeStaticMesure(int staticNoire)
    {
        //Debug.Log("trigger asd");
         this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Triggeradsr, 1f); 
    }



    public void ChangementDePeriodeNoire(float periodeNoire) 
    {
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Attacktimeadsr, 2*periodeNoire );
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Decaytimeadsr, 0*periodeNoire );
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Sustaintimeadsr, 2*periodeNoire );
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Releasetimeadsr, 0*periodeNoire );
    }




}
