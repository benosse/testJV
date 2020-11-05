using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/**********************************************************************************************
BZ
Une enveloppe génère un float entre 0 et 1
Ellee est associée à une AudioLib
Les réglages se font via l'inspecteur

**********************************************************************************************/

public class Enveloppe : MonoBehaviour, EnregistrementStaticNoire, EnregistrementPeriodeNoire
{
    [SerializeField] private Hv_asd_AudioLib enveloppe;

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
        this.metronome.EnregistrerStaticNoire((EnregistrementStaticNoire)this);
        this.metronome.EnregistrerPeriodeNoire((EnregistrementPeriodeNoire)this);

        //récupération de l'audiolib
        this.enveloppe = GetComponent<Hv_asd_AudioLib>();

        //accroche la fonction de callBack 'UpdateEnveloppe' (définie plus bas) à la réception de données depuis l'audiolib
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
        this.enveloppe.SetFloatParameter(Hv_asd_AudioLib.Parameter.Sustaintimeasd, periodeNoire * (float)0.1/6);
        this.enveloppe.SetFloatParameter(Hv_asd_AudioLib.Parameter.Decaytimeasd, periodeNoire * (float) 4.9/6);
    }


    //Cette fonction est un callBack : elle est appelée automatiquement à chaque fois que l'audiolib envoie une nouvelle valeur 'mes'
    private void UpdateEnveloppe(Hv_asd_AudioLib.FloatMessage mes) 
    {

        switch (mes.receiverName)
        {
            case "envAsd":
            //enrgistre la nouvelle valeur
            this.valeur = mes.value;

            //préviens les objets enregistrés
            foreach (Del fonction in enregistrements)
            {
                fonction(this.valeur);
            }

            break;

            case "periodeTimeAsd":
            break;
            
        }
    }

    public void Enregistrer(Del fonction)
    {
        this.enregistrements.Add(fonction);
    }


}
