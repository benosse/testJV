using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
BZ
TODO UTILISER ONBECAMEVISIBLE POUR TOUT gains de perf de folie
//prévoir tout de même des exceptions, si on est en train d'enregistrer un objet par exemple
*/
public class Ble : ActivationParDistance
{

    public GestionnaireADSR enveloppe;
    private Material mat;


    void Start()
    {
        this.mat = gameObject.GetComponent<Renderer> ().material;
        this.enabled = false;
    }


    void Bouger(float valeur)
    {
        this.mat.SetFloat("Deplacement", valeur);
    }


    public void SetEnveloppe(GestionnaireADSR enveloppe)
    {
        this.enveloppe = enveloppe;
    }


    protected override void Activer()
    {
        Debug.Log("child");
        base.Activer();
        this.enveloppe.UpdateValeurDouce += Bouger;
    }

    protected override void Desactiver()
    {   Debug.Log("child out");
        this.enveloppe.UpdateValeurDouce -= Bouger;
        base.Desactiver();
    }
}
