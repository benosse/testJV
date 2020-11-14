using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO
/*
refaire metronome + enveloppe.
métro : il enregistre des fonctions delegate
enveloppes : on règles a, d, s, r, et le trigger avec des sliders dans l'inspecteur

*/

//déclaration des fonctions delegate
public delegate void DelEnregistrementFloat(float valeur);
public delegate void DelEnregistrementInt(int valeur);

public class Metronome : MonoBehaviour
{
    //la librairie
    private Hv_metronome_AudioLib metronomeScript;

    //listes des méthodes enregistrées
    private List<DelEnregistrementInt> enregistrementsMesureCount;
    private List<DelEnregistrementFloat> enregistrementsPeriodeNoire;

    private List<DelEnregistrementInt> enregistrementsStaticMesure;
    private List<DelEnregistrementInt> enregistrementsStaticBlanche;
    private List<DelEnregistrementInt> enregistrementsStaticNoire;
    private List<DelEnregistrementInt> enregistrementsStaticCroche;
    private List<DelEnregistrementInt> enregistrementsStaticDbCroche;
    private List<DelEnregistrementInt> enregistrementsStaticTpCroche;
    private List<DelEnregistrementInt> enregistrementsStaticQdCroche;



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
        //creation des listes vide dans Awake() pour pouvoir y accéder dasn le Start() des enveloppes
        this.enregistrementsMesureCount = new List<DelEnregistrementInt>();
        this.enregistrementsPeriodeNoire = new List<DelEnregistrementFloat>();

        this.enregistrementsStaticMesure = new List<DelEnregistrementInt>();
        this.enregistrementsStaticBlanche = new List<DelEnregistrementInt>();
        this.enregistrementsStaticNoire = new List<DelEnregistrementInt>();
        this.enregistrementsStaticCroche = new List<DelEnregistrementInt>();
        this.enregistrementsStaticDbCroche = new List<DelEnregistrementInt>();
        this.enregistrementsStaticTpCroche = new List<DelEnregistrementInt>();
        this.enregistrementsStaticQdCroche = new List<DelEnregistrementInt>();
    }


    void Start()
    {
        this.metronomeScript = gameObject.GetComponent<Hv_metronome_AudioLib>();
        this.metronomeScript.SetFloatParameter(Hv_metronome_AudioLib.Parameter.Setstaticperiode, 16);
        this.metronomeScript.RegisterSendHook();
        this.metronomeScript.FloatReceivedCallback += this.UpdateMetronome;
    }


    void UpdateMetronome(Hv_metronome_AudioLib.FloatMessage mes)
    {

        switch (mes.receiverName)
        {
            case "metroMesureCount":


                //enregistre la nouvelle valeur
                this.metroMesureCount = (int)mes.value;
                //Debug.Log("metronome nouvelle mesureCount : " + this.metroMesureCount);

                //appelle les méthodes enregistrées
                foreach (DelEnregistrementInt fonction in this.enregistrementsMesureCount)
                {
                    fonction(this.metroMesureCount);
                }

                break;

            case "periodeNoire":

                //enregistre la nouvelle valeur
                this.periodeNoire = mes.value;

                //appelle les méthodes enregistrées
                foreach (DelEnregistrementFloat fonction in this.enregistrementsPeriodeNoire)
                {
                    fonction(this.periodeNoire);
                }

                break;

            case "staticMesure":

                //enregistre la nouvelle valeur
                this.staticMesure = (int)mes.value;
                //Debug.Log("metronome nouvelle staticMesure : " + this.metroMesureCount);

                //appelle les méthodes enregistrées
                foreach (DelEnregistrementInt fonction in this.enregistrementsStaticMesure)
                {
                    fonction(this.staticMesure);
                }

                break;

            case "staticBlanche":

                //enregistre la nouvelle valeur
                this.staticBlanche = (int)mes.value;

                //appelle les méthodes enregistrées
                foreach (DelEnregistrementInt fonction in this.enregistrementsStaticBlanche)
                {
                    fonction(this.staticBlanche);
                }

                break;

            case "staticNoire":

                //enregistre la nouvelle valeur
                this.staticNoire = (int)mes.value;

                //appelle les méthodes enregistrées
                foreach (DelEnregistrementInt fonction in this.enregistrementsStaticNoire)
                {
                    fonction(this.staticNoire);
                }

                break;

            case "staticCroche":

                //enregistre la nouvelle valeur
                this.staticCroche = (int)mes.value;

                //appelle les méthodes enregistrées
                foreach (DelEnregistrementInt fonction in this.enregistrementsStaticCroche)
                {
                    fonction(this.staticCroche);
                }

                break;

            case "staticDbCroche":

                //enregistre la nouvelle valeur
                this.staticDbCroche = (int)mes.value;

                //appelle les méthodes enregistrées
                foreach (DelEnregistrementInt fonction in this.enregistrementsStaticDbCroche)
                {
                    fonction(this.staticDbCroche);
                }

                break;

            case "staticTpCroche":

                //enregistre la nouvelle valeur
                this.staticTpCroche = (int)mes.value;

                //appelle les méthodes enregistrées
                foreach (DelEnregistrementInt fonction in this.enregistrementsStaticTpCroche)
                {
                    fonction(this.staticTpCroche);
                }

                break;

            case "staticQdCroche":

                //enregistre la nouvelle valeur
                this.staticQdCroche = (int)mes.value;

                //appelle les méthodes enregistrées
                foreach (DelEnregistrementInt fonction in this.enregistrementsStaticQdCroche)
                {
                    fonction(this.staticQdCroche);
                }

                break;


            default:
                break;
        }
    }


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
                Debug.Log("aucun désenregistrement possible à  " + nom + "au métronome");
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



}

