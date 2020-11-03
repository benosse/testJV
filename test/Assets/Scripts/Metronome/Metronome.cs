using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{

    private Hv_metronome_AudioLib metronomeScript;


    //une liste d'objets enregistrés.
    private List<EnregistrementAuMetronome> enregistrements;

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


    void Awake() {
        this.enregistrements = new List<EnregistrementAuMetronome>();
    }

    void Start()
    {
        this.metronomeScript = gameObject.GetComponent<Hv_metronome_AudioLib>();
        this.metronomeScript.RegisterSendHook();
        this.metronomeScript.FloatReceivedCallback += this.UpdateMetronome;
    }

    void UpdateMetronome(Hv_metronome_AudioLib.FloatMessage mes)
    {

        switch (mes.receiverName)
        {
            case "metroMesureCount":
                int nouvelleMesure = (int)mes.value;
                Debug.Log("mesure reçue: " + nouvelleMesure);
                //on déclenche des évènements à chaque changement de mesure
                if (nouvelleMesure > this.metroMesureCount)
                {
                    this.ChangementDeMesure();
                }
                this.metroMesureCount = nouvelleMesure;
                break;

            case "periodeNoire":
                this.periodeNoire = mes.value;
                break;

            case "staticMesure":
                this.staticMesure = (int)mes.value;
                break;

            default:
                break;
        }
    }

    private void ChangementDeMesure()
    {
        foreach (EnregistrementAuMetronome obj in this.enregistrements)
        {
            obj.ChangementDeMesure();
        }
    }

    public void Enregistrer(EnregistrementAuMetronome obj)
    {
        enregistrements.Add(obj);
    }
}
