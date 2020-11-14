using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{

    // Tableau de toutes les Souszones
    public List<SousZone> sousZones = new List<SousZone>();

    //un singleton Frequences
    public Frequences frequences;

    public int accord;

    void Awake()
    {
        this.frequences = gameObject.AddComponent<Frequences>();
    }
    void Start()
    {

        foreach (Transform child in transform)
        {
            SousZone sousZone = child.GetComponent<SousZone>();
            if (sousZone != null)
            {
                sousZones.Add(sousZone);
            }
        }

    }

    private void OnValidate()
    {
        foreach (SousZone sousZone in this.sousZones)
        {
            sousZone.SetFrequence();
        }

    }

    public float GetFrequenceOfNote(string note)
    {
        return this.frequences.GetFrequence(this.accord, note);

    }

    void ChangeAccord()
    {
        //code por changer l'accord

        //code pour update les sous-zones
    }
}
