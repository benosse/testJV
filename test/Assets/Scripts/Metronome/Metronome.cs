using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{

    private Hv_metronome_AudioLib metronomeScript;


    //une liste d'objets enregistrés.
    private List<EnregistrementMesure> enregistrementsMesure;
    private List<EnregistrementPeriodeNoire> enregistrementsPeriodeNoire;
    
    private List<EnregistrementStaticMesure> enregistrementsStaticMesure;
    private List<EnregistrementStaticBlanche> enregistrementsStaticBlanche;
    private List<EnregistrementStaticNoire> enregistrementsStaticNoire;
    private List<EnregistrementStaticCroche> enregistrementsStaticCroche;
    private List<EnregistrementStaticDbCroche> enregistrementsStaticDbCroche;
    private List<EnregistrementStaticTpCroche> enregistrementsStaticTpCroche;
    private List<EnregistrementStaticQdCroche> enregistrementsStaticQdCroche;

    

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
        this.enregistrementsMesure = new List<EnregistrementMesure>();
        this.enregistrementsPeriodeNoire = new List<EnregistrementPeriodeNoire>();

        this.enregistrementsStaticMesure = new List<EnregistrementStaticMesure>();
        this.enregistrementsStaticBlanche = new List<EnregistrementStaticBlanche>();
        this.enregistrementsStaticNoire = new List<EnregistrementStaticNoire>();
        this.enregistrementsStaticCroche = new List<EnregistrementStaticCroche>();
        this.enregistrementsStaticDbCroche = new List<EnregistrementStaticDbCroche>();
        this.enregistrementsStaticTpCroche = new List<EnregistrementStaticTpCroche>();
        this.enregistrementsStaticQdCroche = new List<EnregistrementStaticQdCroche>();
    }

    void Start()
    {
        this.metronomeScript = gameObject.GetComponent<Hv_metronome_AudioLib>();
        this.metronomeScript.RegisterSendHook();
        //soubscription à l'event
        this.metronomeScript.FloatReceivedCallback += this.UpdateMetronome;
    }


    void UpdateMetronome(Hv_metronome_AudioLib.FloatMessage mes)
    {

        switch (mes.receiverName)
        {
            case "metroMesureCount":
                
                int nouvelleMesure = (int)mes.value;
                
                if (nouvelleMesure > this.metroMesureCount)
                {
                    //enregistre la nouvelle valeur
                    this.metroMesureCount = nouvelleMesure;

                    //préviens les objets enregistrés
                    foreach (EnregistrementMesure obj in this.enregistrementsMesure)
                {
                    obj.ChangementDeMesure();
                }
                }
                
                break;

            case "periodeNoire":
                //enregistre la nouvelle valeur
                this.periodeNoire = mes.value;
                //préviens les objets enregistrés
                foreach (EnregistrementPeriodeNoire obj in this.enregistrementsPeriodeNoire)
                {
                    obj.ChangementDePeriodeNoire(this.periodeNoire);
                }

                break;

            case "staticMesure":
                this.staticMesure = (int) mes.value;
                foreach (EnregistrementStaticMesure obj in this.enregistrementsStaticMesure)
                {
                    obj.ChangementDeStaticMesure(this.staticMesure);
                }
                break;

            case "staticBlanche":
                this.staticBlanche = (int) mes.value;
                foreach (EnregistrementStaticBlanche obj in this.enregistrementsStaticBlanche)
                {
                    obj.ChangementDeStaticBlanche(this.staticBlanche);
                }
                break;

            case "staticNoire":
                //enregistre la nouvelle valeur
                this.staticNoire = (int) mes.value;
                //préviens les objets enregistrés
                foreach (EnregistrementStaticNoire obj in this.enregistrementsStaticNoire)
                {
                    obj.ChangementDeStaticNoire(this.staticNoire);
                    Debug.Log("metro " + this.staticNoire);
                }
                break;

            case "staticCroche":
                this.staticCroche = (int) mes.value;
                foreach (EnregistrementStaticCroche obj in this.enregistrementsStaticCroche)
                {
                    obj.ChangementDeStaticCroche(this.staticCroche);
                }
                break;

            case "staticDbCroche":
                this.staticDbCroche = (int) mes.value;
                foreach (EnregistrementStaticDbCroche obj in this.enregistrementsStaticDbCroche)
                {
                    obj.ChangementDeStaticDbCroche(this.staticDbCroche);
                }
                break;

            case "staticTpCroche":
                this.staticTpCroche = (int) mes.value;
                foreach (EnregistrementStaticTpCroche obj in this.enregistrementsStaticTpCroche)
                {
                    obj.ChangementDeStaticTpCroche(this.staticTpCroche);
                }
                break;

            case "staticQdCroche":
                this.staticQdCroche = (int) mes.value;
                foreach (EnregistrementStaticQdCroche obj in this.enregistrementsStaticQdCroche)
                {
                    obj.ChangementDeStaticQdCroche(this.staticQdCroche);
                }
                break;


            default:
                break;
        }
    }



    //ajoute l'objet en parametre à la liste d'objest à prévenir en cas de changement de mesure
    public void EnregistrerMesure(EnregistrementMesure obj)
    {
        enregistrementsMesure.Add(obj);
    }
    public void EnregistrerPeriodeNoire(EnregistrementPeriodeNoire obj)
    {
        enregistrementsPeriodeNoire.Add(obj);
    }
    public void EnregistrerStaticMesure(EnregistrementStaticMesure obj)
    {
        enregistrementsStaticMesure.Add(obj);
    }
    public void EnregistrerStaticBlanche(EnregistrementStaticBlanche obj)
    {
        enregistrementsStaticBlanche.Add(obj);
    }
    public void EnregistrerStaticNoire(EnregistrementStaticNoire obj)
    {
        enregistrementsStaticNoire.Add(obj);
    }
    public void EnregistrerStaticCroche(EnregistrementStaticCroche obj)
    {
        enregistrementsStaticCroche.Add(obj);
    }
    public void EnregistrerStaticDbCroche(EnregistrementStaticDbCroche obj)
    {
        enregistrementsStaticDbCroche.Add(obj);
    }
    public void EnregistrerStaticTpCroche(EnregistrementStaticTpCroche obj)
    {
        enregistrementsStaticTpCroche.Add(obj);
    }
    public void EnregistrerStaticQdCroche(EnregistrementStaticQdCroche obj)
    {
        enregistrementsStaticQdCroche.Add(obj);
    }
}
