using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{

    private Hv_metronome_AudioLib metronomeScript;


    //une liste d'objets enregistrés.
    private List<EnregistrementMesure> enregistrementsMesure;
    private List<EnregistrementPeriodeNoire> enregistrementsPeriodeNoire;
    private List<EnregistrementStaticNoire> enregistrementsStaticNoire;

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
        this.enregistrementsStaticNoire = new List<EnregistrementStaticNoire>();
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
                
                //TODO: on devrait pas avoir à checker si la mesure est nouvelle, pourtant on reçoit deux fois l'évènement...
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

            case "staticNoire":
                //enregistre la nouvelle valeur
                this.staticNoire = (int) mes.value;
                //préviens les objets enregistrés
                foreach (EnregistrementStaticNoire obj in this.enregistrementsStaticNoire)
                {
                    obj.ChangementDeStaticNoire(this.staticNoire);
                    //Debug.Log("metro " + this.staticNoire);
                }
                break;

            case "staticMesure":
                this.staticMesure = (int)mes.value;
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

    //ajoute l'objet en parametre à la liste d'objest à prévenir en cas de changement de periode de la noire
    public void EnregistrerPeriodeNoire(EnregistrementPeriodeNoire obj)
    {
        enregistrementsPeriodeNoire.Add(obj);
    }

    //ajoute l'objet en parametre à la liste d'objest à prévenir en cas de changement de la noire static
    public void EnregistrerStaticNoire(EnregistrementStaticNoire obj)
    {
        enregistrementsStaticNoire.Add(obj);
    }
}
