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
    private List<OscilloSixManager> OscilloSixManagers;
    private List<OscilloSixManagerStatique> OscilloSixManagersStatiques;

    private void Awake() {

        this.oscillo = gameObject.GetComponent<Hv_oscilloSix_AudioLib>();
        this.zone = this.transform.parent.GetComponent<Zone>();
        this.OscilloSixManagers = new List<OscilloSixManager>();
        this.OscilloSixManagersStatiques = new List<OscilloSixManagerStatique>();

        foreach (Transform child in transform) { 
            OscilloSixManagersStatiques.Add(child.gameObject.GetComponent<OscilloSixManagerStatique>());
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
        foreach(OscilloSixManagerStatique obj in OscilloSixManagersStatiques){
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

        OscilloSixManagerDynamique OscilloSixManager = other.GetComponent<OscilloSixManagerDynamique>();

        if (OscilloSixManager == null)
        {
            Debug.Log("collision sans objet sonore");
        }
        else
        {
            //ajout à la liste
            this.OscilloSixManagers.Add((OscilloSixManager) OscilloSixManager);
            this.nbHarmoniques = this.OscilloSixManagers.Count;

            //calcul de la fréquence de l'objet


            //OscilloSixManager.SetFrequence()
            //update de l'objet sonore
            //OscilloSixManager.EnterSousZone(this);

            //update du son de la zone
            this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Nbharmo, this.nbHarmoniques);
        }

    }

    //un objet sort de la zone
    void OnTriggerExit(Collider other)
    {
        OscilloSixManagerDynamique OscilloSixManager = other.GetComponent<OscilloSixManagerDynamique>();
        if (OscilloSixManager == null)
        {
            Debug.Log("collision sans objet sonore");
        }
        else
        {
            OscilloSixManager.ExitSousZone(this);

            //on l'enlève de la liste
            this.OscilloSixManagers.Remove(OscilloSixManager);
            this.nbHarmoniques = this.OscilloSixManagers.Count;

            //update du son de la zone
            this.oscillo.SetFloatParameter(Hv_oscilloSix_AudioLib.Parameter.Nbharmo, this.nbHarmoniques);
        }
    }
}
