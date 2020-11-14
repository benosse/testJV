using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************************************************
BZ et Nico
Parent de toutes les enveloppes
***************************************************************************************/

//déclare hors de la classe un type "delegate" qui correspond à une fonction qui prend un float en entrée
//todo : déclarer toutes les delegate du jeu dans un endroit précis? là on a deux fois la même pour metronome et enveloppe
public delegate void Del(float valeur);



public class Enveloppe : MonoBehaviour
{

    [SerializeField] protected Hv_adsr_AudioLib enveloppe;

    protected Metronome metronome;

    //la liste de fonctions déléguées
    protected List<Del> enregistrementsBruts;
    protected List<Del> enregistrementsDoux;
    protected List<Del> enregistrementsTrigger;

    [SerializeField] protected float valeurBrute;
    [SerializeField] protected float valeurDouce;
    [SerializeField] protected float valeurTrigger;

    public enum choixPeriode
    {
        blanche,
        noire,
        croche,
        dbCroche,
        tpCroche,
        qdCroche
    };

    //la periode de l'enveloppe (définie dans l'inspecteur)
    public choixPeriode periode;
    //enregistrement de la valeur de periode en string
    private string periodeString;
    //la fraction de noire correspondant à la string periode
    private float periodeFloat;

    //la periode de la noire donnée par le métronome
    private float periodeNoire;

    //modulo de la période (si on veut une noire sur 4 par exemple...)
    [Range(1, 100)]public int modulo;

    //les valeurs en pourcentage de chaque étape
    [Range(0.0f, 1.0f)] public float dureeAttack;
    [Range(0.0f, 1.0f)] public float dureeDecay;
    [Range(0.0f, 1.0f)] public float dureeSustain;
    [Range(0.0f, 1.0f)] public float dureeRelease;

    //pour information : la durée totale de l'enveloppe (doit être égale à 1 normalement)
    [SerializeField] private float dureeTotale;



    //OnValidate est une méthode appelée automatiquement par unity quand une valeur est changée depuis l'inspecteur
    private void OnValidate()
    {
        //recalcule la durée totale
        this.dureeTotale = this.dureeAttack + this.dureeDecay + this.dureeSustain + this.dureeRelease;

        //recalcul des durées de l'enveloppe
        if (this.enveloppe)
        {
            this.setEnveloppe();
        }

        //réenregistrement
        if (this.metronome)
        {
            this.enregistrerAuMetronome();
        }

        //recalcule de la période
        switch (this.periode)
        {
            case choixPeriode.noire:
                this.periodeFloat = .0f;
                break;
            case choixPeriode.blanche:
                this.periodeFloat = 2f;
                break;
            case choixPeriode.croche:
                this.periodeFloat = 0.5f;
                break;
            case choixPeriode.dbCroche:
                this.periodeFloat = 0.25f;
                break;
            case choixPeriode.tpCroche:
                this.periodeFloat = 0.125f;
                break;
            case choixPeriode.qdCroche:
                this.periodeFloat = 0.0625f;
                break;
            default:
                Debug.Log("periode inconnue");
                break;
        }
    }

    public void Awake()
    {
        enregistrementsBruts = new List<Del>();
        enregistrementsDoux = new List<Del>();
        enregistrementsTrigger = new List<Del>();
    }

    public virtual void Start()
    {

        //enregistrement de l'enveloppe aurpès du métronome
        this.metronome = GameObject.Find("Metronome").GetComponent<Metronome>();
        this.metronome.EnregistrerPeriodeNoire(ChangementDeBPM);

        //récupération de l'audiolib
        this.enveloppe = GetComponent<Hv_adsr_AudioLib>();

        //accroche la fonction de callBack 'UpdateEnveloppe' (définie plus bas) à la réception de données depuis l'audiolib
        this.enveloppe.RegisterSendHook();
        this.enveloppe.FloatReceivedCallback += this.UpdateEnveloppe;

        this.setEnveloppe();
        this.enregistrerAuMetronome();
    }

    //TOUTES les enveloppes sont enregistrées auprès du changement de la période noire au métronome =bpm)
    //quand cette valeur change l'enveloppe recalcule la durée de sustain, decay, attack, release
    public void ChangementDeBPM(float periodeNoire)
    {
        Debug.Log("enveloppe changement bpm");
        //enregistrement de la valeur
        this.periodeNoire = periodeNoire;
        //recalcul des durées de l'enveloppe
        this.setEnveloppe();
    }

    //se réenregistre au métronome
    void enregistrerAuMetronome()
    {
        //Désenregistrement au metronome précédent
        this.metronome.Desenregistrer(this.periodeString, TriggerADSR);

        //Enregistrement au nouvel évènement du métronome
        this.periodeString = this.periode.ToString();
        this.metronome.Enregistrer(this.periodeString, TriggerADSR);
    }

    //calcule les durées réelles en fonction de la période de la noire, de la période de ref, des durées de l'inspecteur
    void setEnveloppe()
    {
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Attacktimeadsr, this.dureeAttack * this.periodeFloat * this.periodeNoire * this.modulo);
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Decaytimeadsr, this.dureeDecay * this.periodeFloat * this.periodeNoire * this.modulo);
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Sustaintimeadsr, this.dureeSustain * this.periodeFloat * this.periodeNoire * this.modulo);
        this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Releasetimeadsr, this.dureeRelease * this.periodeFloat * this.periodeNoire * this.modulo);
    }

    //lance l'ADSR
    public void TriggerADSR(int valeur)
    {
        Debug.Log("valeur:"+valeur + "m:"+this.modulo);
        Debug.Log("modulo "+valeur % this.modulo );

        if (valeur % this.modulo == 0)
        {   
            this.enveloppe.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Triggeradsr, 1f);
        }
    }


    //ajoute la fonction à la liste de fonctions à appeler quand le paramètre change.
    public void EnregistrerBrut(Del fonction)
    {
        this.enregistrementsBruts.Add(fonction);
    }
    public void EnregistrerDoux(Del fonction)
    {
        this.enregistrementsDoux.Add(fonction);
    }

    public void EnregistrerTrigger(Del fonction)
    {
        this.enregistrementsTrigger.Add(fonction);
    }

    //Cette fonction est un callBack : elle est appelée automatiquement à chaque fois que l'audiolib envoie une nouvelle valeur 'mes'
    private void UpdateEnveloppe(Hv_adsr_AudioLib.FloatMessage mes)
    {
        switch (mes.receiverName)
        {
            case "envAdsr":
                //enrgistre la nouvelle valeur
                this.valeurBrute = mes.value;

                //préviens les objets enregistrés
                foreach (Del fonction in enregistrementsBruts)
                {
                    fonction(this.valeurBrute);
                }

                break;

            case "smoothedEnvAdsr":
                //enrgistre la nouvelle valeur
                this.valeurDouce = mes.value;

                //préviens les objets enregistrés
                foreach (Del fonction in enregistrementsDoux)
                {
                    fonction(this.valeurDouce);
                }

                break;

            case "phaseAdsr":

                this.valeurTrigger = mes.value;

                foreach (Del fonction in enregistrementsTrigger)
                {
                    fonction(mes.value);
                }

                break;
        }
    }
}