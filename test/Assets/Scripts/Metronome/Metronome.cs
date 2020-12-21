using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//TODO
/*
BZ
Déclenche des évènements en fonction des valeurs reçues (mesure, blanches, noires, etc...)
*/



public class Metronome : MonoBehaviour
{
    //la librairie
    private Hv_metronome_AudioLib metronomeScript;


    //les différents évènements
    public delegate void ActionUpdate<T>(T valeur);
    public event ActionUpdate <int> UpdateMesureCount;
    public event ActionUpdate <float> UpdatePeriodeNoire;
    public event ActionUpdate <int> UpdateStaticMesure;
    public event ActionUpdate <int> UpdateStaticBlanche;
    public event ActionUpdate <int> UpdateStaticNoire;
    public event ActionUpdate <int> UpdateStaticCroche;
    public event ActionUpdate <int> UpdateStaticDbCroche;
    public event ActionUpdate <int> UpdateStaticTpCroche;
    public event ActionUpdate <int> UpdateStaticQdCroche;


    private int metroMesureCount;
    private float periodeNoire;

    private int staticMesure;
    private int staticBlanche;
    private int staticNoire;
    private int staticCroche;
    private int staticDbCroche;
    private int staticTpCroche;
    private int staticQdCroche;

    private int mesure;
    private int blanche;
    private int noire;
    private int croche;
    private int dbCroche;
    private int tpCroche;
    private int qdCroche;


    void Awake()
    {
    }


    void Start()
    {
        this.metronomeScript = gameObject.GetComponent<Hv_metronome_AudioLib>();
        this.metronomeScript.SetFloatParameter(Hv_metronome_AudioLib.Parameter.Setstaticperiode, 16);
        this.metronomeScript.RegisterSendHook();
        this.metronomeScript.FloatReceivedCallback += this.UpdateMetronome;
    }

    /*
    Update appelé à chaque message reçu du métronome
    Enregistre la valeur et déclenche l'évènement approprié
    */

    void UpdateMetronome(Hv_metronome_AudioLib.FloatMessage mes)
    {

        switch (mes.receiverName)
        {
            case "metroMesureCount":
                this.metroMesureCount = (int) mes.value; 
                if ( this.UpdateMesureCount != null)
                {
                    this.UpdateMesureCount((int) mes.value);
                }
                break;

            case "periodeNoire":
                this.periodeNoire = mes.value;
                if ( this.UpdatePeriodeNoire != null)
                {
                    this.UpdatePeriodeNoire(mes.value);
                }
                break;

            case "staticMesure":
                this.staticMesure = (int) mes.value;
                if ( this.UpdateStaticMesure != null)
                {
                    this.UpdateStaticMesure((int) mes.value);
                }
                break;

            case "staticBlanche":
                this.staticBlanche = (int) mes.value;
                if ( this.UpdateStaticBlanche != null)
                {
                    this.UpdateStaticBlanche((int) mes.value);
                }
                break;

            case "staticNoire":
                this.staticNoire = (int) mes.value;
                if ( this.UpdateStaticNoire!= null)
                {
                    this.UpdateStaticNoire((int) mes.value);
                }
                break;

            case "staticCroche":
                this.staticCroche = (int) mes.value;
                if ( this.UpdateStaticCroche != null)
                {
                    this.UpdateStaticCroche((int) mes.value);
                }
                break;

            case "staticDbCroche":
                this.staticDbCroche = (int) mes.value;
                if ( this.UpdateStaticDbCroche != null) {
                    this.UpdateStaticDbCroche((int) mes.value);
                }
                break;

            case "staticTpCroche":
                this.staticTpCroche = (int) mes.value;
                if ( this.UpdateStaticTpCroche!= null)
                {
                    this.UpdateStaticTpCroche((int) mes.value);
                }
                break;

            case "staticQdCroche":
                this.staticQdCroche = (int) mes.value;
                if ( this.UpdateStaticQdCroche != null)
                {
                    this.UpdateStaticQdCroche((int) mes.value);
                }
                break;

            default:
                break;
        }
    }


/*
    //enlève la méthode de la liste à appeler
    public void Desenregistrer(string nom, DelEnregistrementInt fonction)
    {
        switch (nom)
        {
            case "mesure":
                this.enregistrementsStaticMesure.Remove(fonction);
                break;

            case "noire":
                Debug.Log("remove"+ this.enregistrementsStaticNoire.Count);
                this.enregistrementsStaticNoire.Remove(fonction);
                Debug.Log("remove"+ this.enregistrementsStaticNoire.Count);
                break;

            case "blanche":
                this.enregistrementsStaticBlanche.Remove(fonction);
                break;

            case "croche":
                this.enregistrementsStaticCroche.Remove(fonction);
                break;

            case "dbCroche":
                this.enregistrementsStaticDbCroche.Remove(fonction);
                break;

            case "tpCroche":
                this.enregistrementsStaticTpCroche.Remove(fonction);
                break;

            case "qdCroche":
                this.enregistrementsStaticQdCroche.Remove(fonction);
                break;

            default:
                break;
        }
    }

    //ajoute la méthode de la liste à appeler
    public void Enregistrer(string nom, DelEnregistrementInt fonction)
    {
        switch (nom)
        {
            case "mesure":
                this.enregistrementsStaticMesure.Add(fonction);
                break;

            case "noire":
                this.enregistrementsStaticNoire.Add(fonction);
                break;

            case "blanche":
                this.enregistrementsStaticBlanche.Add(fonction);
                break;

            case "croche":
                this.enregistrementsStaticCroche.Add(fonction);
                break;

            case "dbCroche":
                this.enregistrementsStaticDbCroche.Add(fonction);
                break;

            case "tpCroche":
                this.enregistrementsStaticTpCroche.Add(fonction);
                break;

            case "qdCroche":
                this.enregistrementsStaticQdCroche.Add(fonction);
                break;

            default:
                Debug.Log("aucun enregistrement possible à  " + nom + "au métronome");
                break;
        }
    }


    //un cas spécial puisque elle renvoie un float et non un int
    public void EnregistrerPeriodeNoire(DelEnregistrementFloat fonction)
    {
        enregistrementsPeriodeNoire.Add(fonction);
    }

    public void DesenregistrerPeriodeNoire(DelEnregistrementFloat fonction)
    {
        enregistrementsPeriodeNoire.Remove(fonction);
    }
*/


}

