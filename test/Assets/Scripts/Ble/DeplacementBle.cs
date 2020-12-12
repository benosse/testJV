using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
BZ
TODO UTILISER ONBECAMEVISIBLE POUR TOUT gains de perf de folie
//prévoir tout de même des exceptions, si on est en train d'enregistrer un objet par exemple
*/
public class DeplacementBle : MonoBehaviour
{

    public GestionnaireADSR enveloppe;
    private Material mat;


    void Start()
    {
        this.mat = gameObject.GetComponent<Renderer> ().material;
    }


    void Bouger(float valeur)
    {
        this.mat.SetFloat("Deplacement", valeur);
    }


    public void SetEnveloppe(GestionnaireADSR enveloppe)
    {
        this.enveloppe = enveloppe;
        
    }


    void OnBecameInvisible()
    {
        this.enveloppe.DesenregistrerDoux(Bouger);
        this.enabled = false;
    }


    void OnBecameVisible()
    {
        this.enabled = true;
        this.enveloppe.EnregistrerDoux(Bouger);
    }
}
