using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Micro : MonoBehaviour
{
    //la portée du micro
    public float distanceMax;

    //l'objet actuellement ciblé par le micro
    private EnregistrableParMicro cible;

    //l'objet précédemment ciblé par le micro
    private EnregistrableParMicro ciblePrecedente;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        this.lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    void Update()
    {
        //le rayon
        Ray ray =
            new Ray(transform.position,
                transform.TransformDirection(Vector3.up) * this.distanceMax);

        //la collision du rayon
        RaycastHit hit;

        //affiche le rayon
        this.lineRenderer.SetPosition(0, transform.position);
        this
            .lineRenderer
            .SetPosition(1,
            transform.position +
            transform.TransformDirection(Vector3.up) * this.distanceMax);

        //gestion collision du rayon
        if (Physics.Raycast(ray, out hit))
        {
            this.cible =
                hit.transform.gameObject.GetComponent<EnregistrableParMicro>();

            //si on a pas de cible, on désactive la cible précédente
            if (!cible)
            {
                this.DesactiverCiblePrecedente();
            }
            //si on a la même cible que précédemment
            else  if (this.cible == this.ciblePrecedente)
            {
                //rien pour le moment...
            }

            //sinon on a une nouvelle cible
            else
            {
                //désactive la cible précédente
                this.DesactiverCiblePrecedente();

                //active la nouvelle cible
                this.cible.PreSelectionner();

                //enregistre la cible
                this.ciblePrecedente = this.cible;
            }
        }
    }


    //gère la sortie d'un objet de la portée du micro
    private void DesactiverCiblePrecedente()
    {
        if (this.ciblePrecedente)
        {
            this.ciblePrecedente.SortieDuMicro();
            this.ciblePrecedente = null;
        }   
    }
}
