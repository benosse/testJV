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
*********************************************************************************/
public class SousZone : MonoBehaviour
{

    public string note = "";
    private Zone zone;

    //propriétés de l'oscillo
    protected Hv_oscilloSix_AudioLib oscillo;
    [SerializeField] private float frequence;
    [SerializeField] protected int nbHarmoniques;

    //les objets sonores dans la zone
    private List<ObjetSonore> objetSonores;
    private List<ObjetSonoreStatique> objetSonoresStatiques;

    private void Awake() {

        this.oscillo = gameObject.GetComponent<Hv_oscilloSix_AudioLib>();
        this.zone = this.transform.parent.GetComponent<Zone>();
        this.objetSonores = new List<ObjetSonore>();
        this.objetSonoresStatiques = new List<ObjetSonoreStatique>();

        foreach (Transform child in transform) { 
            objetSonoresStatiques.Add(child.gameObject.GetComponent<ObjetSonoreStatique>());
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
        Debug.Log(this.frequence);
        foreach(ObjetSonoreStatique obj in objetSonoresStatiques){
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
    void OnTriggerEnter(Collider other)
    {

        ObjetSonoreDynamique objetSonore = other.GetComponent<ObjetSonoreDynamique>();

        if (objetSonore == null)
        {
            Debug.Log("collision sans objet sonore");
        }
        else
        {
            //ajout à la liste
            this.objetSonores.Add((ObjetSonore) objetSonore);
            this.nbHarmoniques = this.objetSonores.Count;

            //calcul de la fréquence de l'objet


            //objetSonore.SetFrequence()
            //update de l'objet sonore
            //objetSonore.EnterSousZone(this);

            //update du son de la zone
            this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Nbharmo, this.nbHarmoniques);
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

            //on l'enlève de la liste
            this.objetSonores.Remove(objetSonore);
            this.nbHarmoniques = this.objetSonores.Count;

            //update du son de la zone
            this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Nbharmo, this.nbHarmoniques);
        }
    }
}
