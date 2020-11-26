using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

/***************************************************************************************
BZ et Nico
Parent de toutes les enveloppes
***************************************************************************************/

//déclare hors de la classe un type "delegate" qui correspond à une fonction qui prend un float en entrée
//todo : déclarer toutes les delegate du jeu dans un endroit précis? là on a deux fois la même pour metronome et enveloppe
public delegate void Del(float valeur);



public class GestionnaireADSR : MonoBehaviour
{

    [SerializeField] protected Hv_adsr_AudioLib audioLib;

    protected Metronome metronome;

    //la liste de fonctions déléguées
    protected List<Del> enregistrementsBruts;
    protected List<Del> enregistrementsDoux;
    protected List<Del> enregistrementsTrigger;

    [SerializeField] protected float valeurBrute;
    [SerializeField] protected float valeurDouce;
    [SerializeField] protected float phase;

    public enum forme
    {
        logarithme,
        parabole,
        cosinus,
        lineaire
    }

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
    [Range(1, 100)] public int modulo;

    //les valeurs en pourcentage de chaque étape
    [Range(0.0f, 2.0f)] public float dureeAttack;
    public forme formeAttack;

    [Range(0.0f, 2.0f)] public float dureeDecay;
    public forme formeDecay;

    [Range(0.0f, 2.0f)] public float dureeSustain;
    public forme formeSustain;

    [Range(0.0f, 2.0f)] public float dureeRelease;
    public forme formeRelease;

    //pour information : la durée totale de l'enveloppe (doit être égale à 1 normalement)
    [SerializeField] private float dureeTotale;

    [Range(0.0f, 1.0f)] public float seuil;

    [Range(0.0f, 2000f)] public float smoothEnveloppe;


    public bool reset;
    public bool smoothReset;


    public bool trigger;




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

        //récupération de l'audioLib
        this.audioLib = GetComponent<Hv_adsr_AudioLib>();

        //accroche la fonction de callBack 'UpdateEnveloppe' (définie plus bas) à la réception de données depuis l'audioLib
        this.audioLib.RegisterSendHook();
        this.audioLib.FloatReceivedCallback += this.UpdateEnveloppe;

        this.SetAudioLib();
        this.EnregistrerAuMetronome();
    }

    //OnValidate est une méthode appelée automatiquement par unity quand une valeur est changée depuis l'inspecteur
    private void OnValidate()
    {
        //trigger
        if (this.trigger)
        {
            //on le repasse immédiatement à 0
            this.trigger = false;
            //déclenchement de l'audioLib
            TriggerADSR();
        }

        //recalcule la durée totale
        this.dureeTotale = this.dureeAttack + this.dureeDecay + this.dureeSustain + this.dureeRelease;

        //recalcule de la période
        switch (this.periode)
        {
            case choixPeriode.noire:
                this.periodeFloat = 1f;
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

        //reset l'audioLib
        if (this.audioLib)
        {
            this.SetAudioLib();
        }

        //réenregistrement en cas de changement de période
        if (this.metronome)
        {
            this.EnregistrerAuMetronome();
        }
    }



    //quand la periode noire change,  l'enveloppe recalcule la durée de sustain, decay, attack, release
    public void ChangementDeBPM(float periodeNoire)
    {
        //enregistrement de la valeur
        this.periodeNoire = periodeNoire;
        //recalcul des durées de l'enveloppe
        this.SetAudioLib();
    }

    //enregistrement auprès du métronome
    public void UpdateMetronome(int valeur)
    {
        if (valeur % this.modulo == 0)
        {
            this.TriggerADSR();
        }
    }




    /******************************************************************************************************
    Setteurs de l'enveloppe
    Ils sont appelés automatiquement à chaque changement de l'inspecteur
    Mais peuvent aussi être appelés dans depuis d'autres scripts (séquenceurs?)
    ******************************************************************************************************/

    //déclencehement de  l'ADSR
    public void TriggerADSR()
    {
        this.audioLib.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Triggeradsr, 1f);
    }

    //calcule les durées réelles en fonction de la période de la noire, de la période de ref, des durées de l'inspecteur
    void SetAudioLib()
    {
        this.audioLib.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Attacktimeadsr, this.dureeAttack * this.periodeFloat * this.periodeNoire * this.modulo);
        this.audioLib.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Decaytimeadsr, this.dureeDecay * this.periodeFloat * this.periodeNoire * this.modulo);
        this.audioLib.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Sustaintimeadsr, this.dureeSustain * this.periodeFloat * this.periodeNoire * this.modulo);
        this.audioLib.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Releasetimeadsr, this.dureeRelease * this.periodeFloat * this.periodeNoire * this.modulo);

        this.audioLib.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Formeattackadsr, (int)this.formeAttack);
        this.audioLib.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Formedecayadsr, (int)this.formeDecay);
        this.audioLib.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Formereleaseadsr, (int)this.formeRelease);

        this.audioLib.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Moderesetadsr, this.reset ? 1 : 0);
        this.audioLib.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Smoothreset, this.smoothReset ? 1 : 0);

        this.audioLib.SetFloatParameter(Hv_adsr_AudioLib.Parameter.Smoothenvadsr, this.smoothEnveloppe);
    }

    //se réenregistre au métronome
    void EnregistrerAuMetronome()
    {
        //Désenregistrement au metronome précédent
        this.metronome.Desenregistrer(this.periodeString, UpdateMetronome);

        //Enregistrement au nouvel évènement du métronome
        this.periodeString = this.periode.ToString();
        this.metronome.Enregistrer(this.periodeString, UpdateMetronome);
    }




    /******************************************************************************************************
    Enregistrements auprès de l'enveloppe
    ******************************************************************************************************/

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
                //enrgistre la nouvelle valeur
                this.phase = mes.value;

                //préviens les objets enregistrés
                foreach (Del fonction in enregistrementsTrigger)
                {
                    fonction(mes.value);
                }

                break;
        }
    }
}