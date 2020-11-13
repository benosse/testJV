using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troupeau : MonoBehaviour
{
    public Enveloppe enveloppe;
    private Vector3 centre;
    [SerializeField]
    private float rayonMin;

    [SerializeField]
    private float rayonMax;

    //les lapisn du troupeau
    private List<GameObject> lapins;


    //propriétés pour le déplacement du troupeau
    [SerializeField]
    private bool enMouvement;
    private int indexPrecedent;



    //DEBUG
    private GameObject cube;

    private void Awake()
    {
        this.lapins = new List<GameObject>();
        //récupère tous les enfants
        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponentInChildren<DeplacementLapin>())
                lapins.Add(child.gameObject);
            else
                this.cube = child.gameObject;
        }
    }
    void Start()
    {
        this.enveloppe.EnregistrerDoux(Bouger);
        this.enveloppe.EnregistrerTrigger(TriggerBouger);

        this.rayonMax = 16;
        this.rayonMin = 8;
    }

    //déplace le troupeau seulement en phase attaque
    void TriggerBouger(float valeur)
    {
        if (valeur == 4 )
        {
            this.enMouvement = true;

            //calcule le centre du troupeau
            this.centre = new Vector3();
            foreach (GameObject obj in lapins)
            {
                this.centre += obj.transform.position;
            }
            this.centre = this.centre / this.lapins.Count;
            this.centre.y = 0;

            //bouge le centre aléatoirement
            this.centre = this.centre + (Random.onUnitSphere * this.rayonMax);
            this.centre.y = 0;
            this.cube.transform.position = this.centre;
        }

        /*
        else if (valeur == 4 && this.enMouvement) {
            this.enMouvement = false;
            foreach (GameObject obj in lapins)
            {
                obj.GetComponent<DeplacementLapin>().Stop();
            }
        }
        */
    }



    //déplace les lapins un à un
    void Bouger(float valeur)
    {
        //on bouge pendant l'attaque de l'enveloppe
        if (this.enMouvement)
        {
            //sélectionne les lapins un par un
            int index = (int)Mathf.Floor(valeur * (lapins.Count));
            //check qu'on appelle cette fonction qu'une seule fois par lapin
            if (index != this.indexPrecedent)
            {
                DeplacementLapin deplacement = lapins[index].GetComponent<DeplacementLapin>();
                deplacement.BougerVers(this.centre, this.rayonMin);

                this.indexPrecedent = index;
            }
        }
    }
}
