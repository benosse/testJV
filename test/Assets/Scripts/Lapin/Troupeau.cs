using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troupeau : MonoBehaviour
{
    public Enveloppe enveloppe;
    private Vector3 centre;

    //les lapisn du troupeau
    private List<GameObject> lapins;

    private void Awake()
    {
        this.lapins = new List<GameObject>();
        //récupère tous les enfants
        foreach (Transform child in transform)
        {
            lapins.Add(child.gameObject);
        }
    }
    void Start()
    {
        this.enveloppe.EnregistrerTrigger(Bouger);
    }

    void Bouger(float valeur)
    {
        //ne réagit qu'au trigger de début
        if (valeur != 0)
            return;

        Debug.Log("move");

        //calcule le centre du troupeau
        this.centre = new Vector3();
        foreach (GameObject obj in lapins)
        {
            this.centre += obj.transform.position;
        }
        this.centre = this.centre/this.lapins.Count;
        this.centre.y = 0;

        //bouge le groupe au nouveau centre
        //this.transform.position = this.centre;

        //fais bouger les lapins
        foreach (GameObject obj in lapins)
        {
            DeplacementLapin deplacement = obj.GetComponent<DeplacementLapin>();
            deplacement.BougerVers(this.centre);
        }

        Debug.Log("bouge troupeau " + valeur);
    }
}
