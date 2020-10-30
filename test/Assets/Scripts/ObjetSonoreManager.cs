using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetSonoreManager : MonoBehaviour
{

    //liste d'ObjetSonore
    private List<ObjetSonore> objetsSonores;

    //un métronome
    private Hv_metronome_AudioLib metronomeScript;

    private Metronome metronome;

 

    void Awake()
    {
        this.objetsSonores = new List<ObjetSonore>();

        this.metronomeScript = GameObject.Find("Metronome").GetComponent<Hv_metronome_AudioLib>();
        this.metronomeScript.RegisterSendHook();
        this.metronomeScript.FloatReceivedCallback += UpdateMetronome;

        this.metronome = new Metronome();
    }

    //ajoute un objet sonore à  la liste
    public void AddObjetSonore(ObjetSonore obj)
    {
        this.objetsSonores.Add(obj);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.objetsSonores.Count);
        foreach (ObjetSonore obj in this.objetsSonores)
        {
            Debug.Log("metro : " + this.metronome.GetMetroMesureCount());
            obj.SetMixerCycleTime(this.metronome.GetPeriodeNoire()*2);
        }


    }


    void UpdateMetronome(Hv_metronome_AudioLib.FloatMessage mes)
    {
        switch (mes.receiverName)
        {
            case "metroMesureCount":
                this.metronome.SetMetroMesureCount(mes.value);
                break;
            case "periodeNoire":
                this.metronome.SetPeriodeNoire(mes.value);
                break;
            case "staticMesure":
                this.metronome.SetStaticMesure(mes.value);
                break;
            default:
                break;
        }
    }

}
