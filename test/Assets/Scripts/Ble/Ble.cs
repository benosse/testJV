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
    private bool enregistre = false;


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


    protected override void OnBecameInvisible()
    {
          base.OnBecameInvisible();
    }


    protected override void OnBecameVisible()
    {
        base.OnBecameVisible();

        //on se réenregistre seulement si on est pas déjà enregistré
        if (!this.enregistre)
        {
            this.enveloppe.EnregistrerDoux(Bouger);
            this.enregistre = true;
        } 
    }
}
