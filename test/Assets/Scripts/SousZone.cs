using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*********************************************************************************
classe SousZone, correspond à une note de l'accord
contient une note définie dans l'inspecteur (tonique, tierce, quinte ou septième)
contient une zone parent (accord)
sa fréquence est déterminée en fonction de sa zone et de sa note
*********************************************************************************/
public class SousZone : MonoBehaviour
{

    public string note = "";
    private Zone zone;
    [SerializeField] private float frequence = 0;


    //Récupération de la zone parent et calcul de la fréquence
    void Start()
    {
        this.zone = this.transform.parent.GetComponent<Zone>();
        SetFrequence();  
    }

    public void SetFrequence()
    {
        this.frequence = this.zone.GetFrequenceOfNote(this.note);  
    }


    public float GetFrequence()
    {
        return this.frequence;
    }

    //un objet rentre dans la sousZone
    //si c'est un objet sonore on change sa fréquence
    //TODO peut être?: inverser les trigger si possible (les mettre sur les objets qui rentrent dans la zone)
    void OnTriggerEnter(Collider other)
    {

        ObjetSonoreDynamique objetSonore = other.GetComponent<ObjetSonoreDynamique>();

        if (objetSonore == null)
        {
            Debug.Log("collision sans objet sonore");
        }
        else
        {
            objetSonore.EnterSousZone(this);
        }

    }

    //un objet sort de la zone
    void OnTriggerExit(Collider other)
    {
        ObjetSonoreDynamique objetSonore = other.GetComponent<ObjetSonoreDynamique>();
        if (objetSonore == null)
        {
            Debug.Log("collision sans objet sonore");
        }
        else
        {
            objetSonore.ExitSousZone(this);
        }
    }
}
