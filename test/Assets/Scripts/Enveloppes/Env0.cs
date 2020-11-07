using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Env0 : MonoBehaviour, EnregistrementStaticMesure, EnregistrementPeriodeNoire
{
    [SerializeField] private Hv_adsr_AudioLib env0;

    //la valeur entre 0 et 1 de l'enveloppe
    [SerializeField] private float valeur;

    //le metronome
    private Metronome metronome;


    //la fonction déléguée à appeler après des objets enregistrés
    public delegate void Del(float valeur);

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

        this.env0.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Attacktimeadsr, periodeNoire * (float) (4 * 2/6));
        this.env0.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Decaytimeadsr, periodeNoire * (float) (4* 1/6));
        this.env0.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Sustaintimeadsr, periodeNoire * (float)(4*1/12));
        this.env0.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Releasetimeadsr, periodeNoire * (float)(4* 7/12));
    }


    //Cette fonction est un callBack : elle est appelée automatiquement à chaque fois que l'audiolib envoie une nouvelle valeur 'mes'
    private void UpdateEnv0(Hv_adsr_AudioLib.FloatMessage mes) 
    {

        switch (mes.receiverName)
        {
            case "envAdsr":
            //enrgistre la nouvelle valeur
            this.valeur = mes.value;

            //préviens les objets enregistrés
            foreach (Del fonction in enregistrements)
            {
                fonction(this.valeur);
            }

            break;

            case "periodeTimeAdsr":
            break;
            
        }
    }

    public void Enregistrer(Del fonction)
    {
        this.enregistrements.Add(fonction);
    }


}
