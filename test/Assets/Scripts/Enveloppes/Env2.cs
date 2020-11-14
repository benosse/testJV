using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Env2 : Enveloppe, EnregistrementStaticCroche,EnregistrementStaticMesure , EnregistrementPeriodeNoire 
{
    
    public override void Start()
    {
        // appel de la méthode Start de la classe parent
        base.Start();

        //this.metronome.EnregistrerStaticMesure((EnregistrementStaticMesure)this);
        //this.metronome.EnregistrerStaticCroche((EnregistrementStaticCroche)this);
        //this.metronome.EnregistrerPeriodeNoire((EnregistrementPeriodeNoire)this);
    }


    public void ChangementDeStaticCroche(int staticCroche)
    {
        //Debug.Log("trigger asd");
         //this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Triggeradsr, 1f); 
    }
    public void ChangementDeStaticMesure(int staticMesure)
    {
        //Debug.Log("staticMesure: " + staticMesure);
        if (staticMesure%4==0){
            this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Triggeradsr, 1f); 
        }
    }



    public void ChangementDePeriodeNoire(float periodeNoire) 
    {

        //Debug.Log("nouvelle per noire : " + periodeNoire);

        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Attacktimeadsr, periodeNoire * 4);
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Decaytimeadsr, periodeNoire );
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Sustaintimeadsr, periodeNoire * 4);
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Releasetimeadsr, periodeNoire * 7);
    }




}
