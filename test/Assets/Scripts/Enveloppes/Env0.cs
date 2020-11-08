using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Env0 : MonoBehaviour, EnregistrementStaticMesure, EnregistrementPeriodeNoire
{
    [SerializeField] private Hv_adsr_AudioLib env0;

    //la valeur entre 0 et 1 de l'enveloppe
    [SerializeField] private float valeur;
    [SerializeField] private float valeurInterpolee;

    //le metronome
    private Metronome metronome;


    //la fonction déléguée à appeler après des objets enregistrés
    public delegate void Del(float valeur) ;
    

    //la liste de fonctions déléguées
    private List<Del> enregistrements;



    void Awake() {
       enregistrements = new List<Del>();
    }



    void Start()
    {

        //enregistrement de l'enveloppe aurpès du métronome
        this.metronome = GameObject.Find("Metronome").GetComponent<Metronome>();
        this.metronome.EnregistrerStaticMesure((EnregistrementStaticMesure)this);
        this.metronome.EnregistrerPeriodeNoire((EnregistrementPeriodeNoire)this);

        //récupération de l'audiolib
        this.env0 = GetComponent<Hv_adsr_AudioLib>();

        this.env0.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Moderesetadsr, 0f);
        this.env0.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Seuiladsr, 0.2f);

        this.env0.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Smoothenvadsr, 500f);

        this.env0.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Attacktimeadsr, 800);
        this.env0.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Decaytimeadsr,800);
        this.env0.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Sustaintimeadsr, 50);
        this.env0.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Releasetimeadsr, 1000);

        this.env0.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Formeattackadsr,0f);
        this.env0.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Formedecayadsr, 1f);
        this.env0.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Formereleaseadsr, 2f);
        this.env0.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Smoothreset, 0f);

        
        

        //accroche la fonction de callBack 'UpdateEnveloppe' (définie plus bas) à la réception de données depuis l'audiolib
        this.env0.RegisterSendHook();
        this.env0.FloatReceivedCallback += this.UpdateEnv0;     
    }


    public void ChangementDeStaticMesure(int staticMesure)
    {
         this.env0.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Triggeradsr, 1f); 
         
    }

    /*public void ChangementDeStaticNoire(int staticNoire)
    {
        //1Debug.Log("trigger asd");
         this.enveloppe.SetFloatParameter(Hv_asd_AudioLib.Parameter.Triggerasd, 1f); 
    }*/



    public void ChangementDePeriodeNoire(float periodeNoire) 
    {

        Debug.Log("nouvelle per noire : " + periodeNoire);
/*
        this.env0.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Attacktimeadsr, periodeNoire * (float) 8/6);
        this.env0.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Decaytimeadsr, periodeNoire * (float) 4/6);
        this.env0.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Sustaintimeadsr, periodeNoire * (float)4/12);
        this.env0.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Releasetimeadsr, periodeNoire * (float)28/12);
        */
    }


    //Cette fonction est un callBack : elle est appelée automatiquement à chaque fois que l'audiolib envoie une nouvelle valeur 'mes'
    private void UpdateEnv0(Hv_adsr_AudioLib.FloatMessage mes) 
    {

        switch (mes.receiverName)
        {
            case "smoothedEnvAdsr":
            //enrgistre la nouvelle valeur
            this.valeur = mes.value;

            //préviens les objets enregistrés
            foreach (Del fonction in enregistrements)
            {
                fonction(this.valeur);
            }

            break;
/*
            case "smoothedEnvAdsr":
            //enrgistre la nouvelle valeur
            this.valeurInterpolee = mes.value;
            

            //préviens les objets enregistrés
            foreach (Del fonction in enregistrements)
            {
                fonction(this.valeurInterpolee);
            }

            break;*/
        

            
            
        }
    }

    public void Enregistrer(Del fonction)
    {
        this.enregistrements.Add(fonction);
    }


}
