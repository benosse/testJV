using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementBle : MonoBehaviour
{

    public GestionnaireADSR enveloppe;
    private Material mat;


    void Start()
    {
        Debug.Log("ble" + gameObject.name);
        if (this.enveloppe)
        {
            this.enveloppe.EnregistrerDoux(Bouger);
        }
        
        this.mat = gameObject.GetComponent<Renderer> ().material;
    }

    void Bouger(float valeur)
    {
        this.mat.SetFloat("Deplacement", valeur);
    }
}
