using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************************************************
BZ et Nico
interface de toutes les enveloppes
***************************************************************************************/

public delegate void Del(float valeur);

public class Enveloppe : MonoBehaviour
{

    [SerializeField] protected Hv_adsr_AudioLib enveloppe;

    //le metronome
    protected Metronome metronome;

    //la liste de fonctions déléguées
    protected List<Del> enregistrementsBruts;
    protected List<Del> enregistrementsDoux;
    protected List<Del> enregistrementsTrigger;
    //TODO pour chgmt phases

    [SerializeField] protected float valeurBrute;
    [SerializeField] protected float valeurDouce;
    [SerializeField] protected float valeurTrigger;



    public void Awake() {
       enregistrementsBruts = new List<Del>();
       enregistrementsDoux = new List<Del>();
       enregistrementsTrigger = new List<Del>();
    }

    public virtual void Start() {

        //enregistrement de l'enveloppe aurpès du métronome
        this.metronome = GameObject.Find("Metronome").GetComponent<Metronome>();

        //récupération de l'audiolib
        this.enveloppe = GetComponent<Hv_adsr_AudioLib>();

        //accroche la fonction de callBack 'UpdateEnveloppe' (définie plus bas) à la réception de données depuis l'audiolib
        this.enveloppe.RegisterSendHook();
        this.enveloppe.FloatReceivedCallback += this.UpdateEnveloppe;  
    }

   
    //la méthode appelée par le métronome quand il change de mesure
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