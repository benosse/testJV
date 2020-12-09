using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*********************************************************************************
classe SousZone, correspond à une note de l'accord
contient une note définie dans l'inspecteur (tonique, tierce, quinte ou septième)
contient une zone parent (accord)
sa fréquence est déterminée en fonction de sa zone et de sa note

update:
Elle contient aussi un ocsillo
SOn nb d'harmonies varie en fonction des objets présents

update2:
*********************************************************************************/
public class SousZone : MonoBehaviour
{

    public string note = "";
    private Zone zone;

    //propriétés de l'oscillo
    private Hv_oscilloSix_AudioLib oscillo;
    [SerializeField] private float frequence;
    [SerializeField] private int nbHarmoniques;

    //les objets  dans la zone
    private List<FrequenceParZone> enfants;




    private void Awake() {

        this.oscillo = gameObject.GetComponent<Hv_oscilloSix_AudioLib>();
        this.zone = this.transform.parent.GetComponent<Zone>();

        this.enfants = new List<FrequenceParZone>();

        foreach (Transform child in transform) { 
            enfants.Add(child.gameObject.GetComponent<FrequenceParZone>());
        }

    }


    //Récupération de la zone parent et calcul de la fréquence
    void Start()
    {  
        this.nbHarmoniques = 0;  
        this.SetFrequence();   
    }

    public void SetFrequence()
    {
        this.frequence = this.zone.GetFrequenceOfNote(this.note);  

        this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Freqmaster, frequence);

        foreach(FrequenceParZone obj in enfants){
            obj.SetFrequence(this.frequence);
        }        
    }


    public float GetFrequence()
    {
        return this.frequence;
    }

    public int GetNbHarmoniques()
    {
        return this.nbHarmoniques;
    }

    //un objet rentre dans la sousZone
    //si c'est un objet sonore on change sa fréquence
    //TODO peut être?: inverser les trigger si possible (les mettre sur les objets qui rentrent dans la zone)
    void OnTriggerEnter(Collider entrant)
    {
        FrequenceParZone frequenceParZone = entrant.GetComponent<FrequenceParZone>();

        if (frequenceParZone == null)
        {
            //Debug.Log("collision sans objet sonore");
        }
        else
        {
            //ajout à la liste
            this.enfants.Add((FrequenceParZone) frequenceParZone);
            this.nbHarmoniques = this.enfants.Count;


            frequenceParZone.EnterSousZone(this);
            //update du son de la zone
            this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Nbharmo, this.nbHarmoniques);
        }

    }

    //un objet sort de la zone
    void OnTriggerExit(Collider entrant)
    {
        FrequenceParZone frequenceParZone = entrant.GetComponent<FrequenceParZone>();
        if (frequenceParZone == null)
        {
            //Debug.Log("collision sans objet sonore");
        }
        else
        {
            frequenceParZone.ExitSousZone(this);

            //on l'enlève de la liste
            this.enfants.Remove(frequenceParZone);
            this.nbHarmoniques = this.enfants.Count;

            //update du son de la zone
            this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Nbharmo, this.nbHarmoniques);
        }
    }
}
