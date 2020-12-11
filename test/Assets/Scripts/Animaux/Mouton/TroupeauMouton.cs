using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//utilitaires de tri
using System.Linq;

/*
BZ
TODO : le refaire avec un navmesh pour gérer la destination
En faire un préfab, pouvoir indiquer le nombre de créatures qu'on veut, leur type...
*/
public class TroupeauMouton : MonoBehaviour
{
    public GestionnaireADSR enveloppe;

    //le centre du troupeau
    private Vector3 centre;

    //le distances de déplacement
    private float rayonMin;
    private float rayonMax;

    //les moutons du troupeau
    private List<GameObject> moutons;

    //propriétés pour le déplacement du troupeau
    [SerializeField] private bool enMouvement;



    private int indexPrecedent;


    //DEBUG : cube pour visualiser la destination
    private GameObject cube;


    private void Awake()
    {
        this.moutons = new List<GameObject>();

        //récupère tous les enfants
        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponentInChildren<DeplacementMouton>())
                moutons.Add(child.gameObject);
        }

        //le cube pour le debug
        this.cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    }


    void Start()
    {
        this.enveloppe.EnregistrerDoux(Bouger);
        this.enveloppe.EnregistrerTrigger(TriggerBouger);

        this.rayonMax = 40;
        this.rayonMin = 8;
    }


    //déplace le troupeau seulement en phase attaque
    void TriggerBouger(float valeur)
    {
        if (valeur == 0)
        {
            this.enMouvement = true;

            //calcule le centre du troupeau
            this.centre = new Vector3();
            foreach (GameObject obj in moutons)
            {
                this.centre += obj.transform.position;
            }
            this.centre = this.centre / this.moutons.Count;
            this.centre.y = 0;

            //bouge le centre aléatoirement
            //todo : vérfier que le nouveau centre est sur la map
            Vector2 random = Random.insideUnitCircle.normalized;
            this.centre = this.centre + new Vector3(random.x, 0, random.y) * this.rayonMax;
            this.centre.y = 0;
            this.cube.transform.position = this.centre;

            //trie la liste des moutons en fonction du nouveau centre
            this.moutons = this.moutons.OrderBy(
                x => Vector3.Distance(this.centre, x.transform.position)
            ).ToList();
            
        }


        else if (valeur == 4 && this.enMouvement)
        {
            this.enMouvement = false;
            foreach (GameObject obj in moutons)
            {
                obj.GetComponent<DeplacementMouton>().Stop();
            }
        }

    }


    //déplace les moutons un à un
    void Bouger(float valeur)
    {
        //on bouge pendant l'attaque de l'enveloppe
        if (this.enMouvement)
        {
            //sélectionne les moutons un par un
            int index = (int)Mathf.Floor(valeur * (moutons.Count));
            //check qu'on appelle cette fonction qu'une seule fois par lapin
            if (index != this.indexPrecedent && index >= 0 && index < this.moutons.Count)
            {
                DeplacementMouton deplacement = moutons[index].GetComponent<DeplacementMouton>();
                deplacement.BougerVers(this.centre, this.rayonMin);

                this.indexPrecedent = index;
            }
        }
    }
}
