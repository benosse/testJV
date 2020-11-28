using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Micro : MonoBehaviour
{
    //l'objet actuellement ciblé par le micro
    private EnregistrableParMicro cibleActuelle;
    //Le mixer gestionnaire de mixer Sampler rattaché au micro
    Sampler sampler;

    //la portée du micro
    public float distanceMax;

    //visualisation de la portée du micro
    private LineRenderer lineRenderer;
    private Color couleurPreSelection = Color.yellow;
    private Color couleurEnregistrement = Color.green;

    private bool enregistrementEnCours = false;
    private float dureeEnregistrement = 0f;
    private float dureeEnregistrementMax = 2;



    private void Awake()
    {
        this.sampler = gameObject.GetComponent<Sampler>();

        //visualisation du rayon
        this.lineRenderer = gameObject.GetComponent<LineRenderer>();
        this.lineRenderer.SetPosition(0, Vector3.zero );
        this.lineRenderer.SetPosition(1, new Vector3(0, this.distanceMax/this.transform.localScale.x, 0));
    }

    //gère l'arret d'un enregistrement
    private void ArreterEnregistrement()
    {
        //le sampler
        this.sampler.ArreterEnregistrement();
        //la cible
        this.cibleActuelle.SortieEnregistrement();
        //le micro
        this.enregistrementEnCours = false;
        this.dureeEnregistrement = 0f;
        this.lineRenderer.startColor = this.couleurPreSelection;
        this.lineRenderer.endColor = this.couleurPreSelection;
    }

    //gère le lancement d'un enregistrement
    private void CommencerEnregistrement()
    {
        GestionnaireMixer cibleGestionnaireMixer = this.cibleActuelle.gameObject.GetComponent<GestionnaireMixer>();
        if (cibleGestionnaireMixer)
        {
            //le sampler
            this.sampler.Enregistrer(cibleGestionnaireMixer);
            //la cible
            this.cibleActuelle.Enregistrer();
            this.enregistrementEnCours = true;
            //le micro
            this.lineRenderer.startColor = this.couleurEnregistrement;
            this.lineRenderer.endColor = this.couleurEnregistrement;
        }
        else
        {
            Debug.Log("la cible du micro n'as pas de gestionnaire de mixer, impossible de lancer l'enregistrement du sampler");
        }
    }

    //quand on est en train d'enregistrer
    private void UpdateEnregistrer()
    {
        this.dureeEnregistrement += Time.deltaTime;
        if (this.dureeEnregistrement >= this.dureeEnregistrementMax)
        {
            this.ArreterEnregistrement();
        }
    }

    //les évènements
    // la touche espace active l'enregsitrement (rester appuyé)
    //fin de l'enregistrement quand on relève la touche
    private void gestionEvenements()
    {
        if (Input.GetKeyDown("space"))
        {
            if (this.cibleActuelle)
            {
                this.CommencerEnregistrement();
            }
        }

        if (Input.GetKeyUp("space"))
        {
            if (this.enregistrementEnCours)
            {
                ArreterEnregistrement();
            }
        }
    }

    void Update()
    {
        this.gestionEvenements();

        //si on est en cours d'enregistrement
        if (this.enregistrementEnCours)
        {
            this.UpdateEnregistrer();
        }
        else
        //sinon on fait un lancer de rayon pour scanner l'environnement
        {
            //le rayon
            Ray ray =
                new Ray(transform.position, transform.TransformDirection(Vector3.up));

            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up)*this.distanceMax, Color.green);

            //la collision du rayon
            RaycastHit hit;

            //gestion collision du rayon
            if (Physics.Raycast(ray, out hit, this.distanceMax))
            {
                EnregistrableParMicro cible = hit.transform.gameObject.GetComponent<EnregistrableParMicro>();

                //si on a pas de cible, on désactive la cible précédente
                if (!cible)
                {
                    this.DesactiverCiblePrecedente();
                } 
                
                //si on a la même cible que précédemment
                else if (cible == this.cibleActuelle)
                {
                    //rien pour le moment...
                }

                else
                //sinon on a une nouvelle cible
                {
                    //désactive la cible précédente
                    this.DesactiverCiblePrecedente();
                    //enregistre la cible
                    this.cibleActuelle = cible;
                    //active la nouvelle cible
                    cible.PreSelectionner();
                }
            }

            //pas de collision avec le rayon
            else {
                this.DesactiverCiblePrecedente();
            }
        }
    }

    //gère la sortie d'un objet de la portée du micro
    private void DesactiverCiblePrecedente()
    {
        if (this.cibleActuelle)
        {
            this.cibleActuelle.SortiePreSelection();
            this.cibleActuelle = null;
        }
    }
}
