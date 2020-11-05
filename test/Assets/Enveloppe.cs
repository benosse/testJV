using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enveloppe : MonoBehaviour, EnregistrementStaticNoire, EnregistrementPeriodeNoire
{
    [SerializeField] private Hv_asd_AudioLib enveloppe;

    [SerializeField] private float envAsd;

    private List<ObjetSonore> enregistementsEnveloppe;


    void Awake() {
       enregistementsEnveloppe = new List<ObjetSonore>();
    }

    // Start is called before the first frame update
    void Start()
    {

        GameObject metronome = GameObject.Find("Metronome");
        metronome.GetComponent<Metronome>().EnregistrerStaticNoire((EnregistrementStaticNoire)this);
        metronome.GetComponent<Metronome>().EnregistrerPeriodeNoire((EnregistrementPeriodeNoire)this);
        this.enveloppe = GetComponent<Hv_asd_AudioLib>();

        /*
        this.enveloppe.SetFloatParameter(Hv_asd_AudioLib.Parameter.Attacktimeasd, 50);
        this.enveloppe.SetFloatParameter(Hv_asd_AudioLib.Parameter.Sustaintimeasd, 150);
        this.enveloppe.SetFloatParameter(Hv_asd_AudioLib.Parameter.Decaytimeasd, 600);
        */

        this.enveloppe.RegisterSendHook();
        this.enveloppe.FloatReceivedCallback += this.UpdateEnveloppe;     
    }


    public void ChangementDeStaticNoire(int staticNoire)
    {
        Debug.Log("trigger asd");
         this.enveloppe.SetFloatParameter(Hv_asd_AudioLib.Parameter.Triggerasd, 1f); 
    }



    public void ChangementDePeriodeNoire(float periodeNoire) 
    {

        Debug.Log("nouvelle per noire : " + periodeNoire);

        this.enveloppe.SetFloatParameter(Hv_asd_AudioLib.Parameter.Attacktimeasd, periodeNoire * 1/6);
        this.enveloppe.SetFloatParameter(Hv_asd_AudioLib.Parameter.Sustaintimeasd, periodeNoire * 1/6);
        this.enveloppe.SetFloatParameter(Hv_asd_AudioLib.Parameter.Decaytimeasd, periodeNoire * 4/6);
    }



    private void UpdateEnveloppe(Hv_asd_AudioLib.FloatMessage mes) 
    {
        Debug.Log("reçu : " + mes.receiverName + mes.value);
        switch (mes.receiverName)
        {
            case "envAsd":
            //enrgistre la nouvelle valeur
            this.envAsd = mes.value;

            //préviens
            foreach (ObjetSonore obj in enregistementsEnveloppe)
            {
                obj.SetGain(this.envAsd);
            }

            break;

            case "periodeTimeAsd":
            break;
            
        }
    }

    public void EnregistrerObjetSonore(ObjetSonore obj)
    {
        this.enregistementsEnveloppe.Add(obj);
    }


}
