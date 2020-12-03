using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SamplerGranulaire : MonoBehaviour
{
    //l'objet actuellement ciblé par le sampler
    
    [SerializeField] private EnregistrableParMicro cibleActuelle;
    [SerializeField] private EnregistrableParMicro nouvelleCible;

    //la portée du sampler
    public float distanceMax;

    //visualisation de la portée du sampler
    private LineRenderer lineRenderer;
    private Color couleurPreSelection = Color.yellow;
    private Color couleurEnregistrement = Color.green;

    private bool lectureEnCours = false;

    //le mixer du sampler et ses groupes
    private AudioMixer samplerMixer;
    private AudioMixerGroup dry;
    private AudioMixerGroup wet;

    public string nom;



    private void Awake()
    {
        //récupération du mixer
        this.samplerMixer = Resources.Load<AudioMixer>(this.nom);
        this.dry = this.samplerMixer.FindMatchingGroups("Dry")[0];
        this.wet = this.samplerMixer.FindMatchingGroups("Wet")[0];


        //visualisation du rayon
        this.lineRenderer = gameObject.GetComponent<LineRenderer>();
        this.lineRenderer.SetPosition(0, Vector3.zero );
        this.lineRenderer.SetPosition(1, new Vector3(0, this.distanceMax/this.transform.localScale.x, 0));
        
        this.lineRenderer.startColor = this.couleurEnregistrement;
        this.lineRenderer.endColor = this.couleurEnregistrement;
    }



    //*****************************************************************************************************
    //EVENEMENTS    
    //*****************************************************************************************************
    private void gestionEvenements()
    {
        if (Input.GetKeyDown("space"))
        {
            //libère la cible précédente
            if (this.cibleActuelle)
            {
                this.cibleActuelle.SortieEnregistrement();
                this.cibleActuelle = null;
            }

            //enregistre la nouvelle
            if (this.nouvelleCible)
            {
                this.cibleActuelle = this.nouvelleCible;
                this.cibleActuelle.Enregistrer(this.dry);
                this.samplerMixer.SetFloat("record", 1f);
            }
        }

        if (Input.GetKeyDown("p"))
        {
            if (this.lectureEnCours)
            {
                this.ArreterJouer();
            }
            else
            {
                this.Jouer();
            }
        }
    }


    //*****************************************************************************************************
    //JOUER LE SON ENREGISTRE
    //*****************************************************************************************************
    private void Jouer()
    {
        this.lectureEnCours = true;
        this.samplerMixer.SetFloat("playGrains", 1f);
    }

    private void ArreterJouer()
    {
        this.lectureEnCours = false;
        this.samplerMixer.SetFloat("playGrains", 0f);
    }


    //*****************************************************************************************************
    //UPDATE
    //*****************************************************************************************************
    void Update()
    {
        //surveille les évènements claviers
        this.gestionEvenements();

        //le rayon
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.up));
        //la collision du rayon
        RaycastHit hit;

        //collision du rayon
        if (Physics.Raycast(ray, out hit, this.distanceMax))
        {
            EnregistrableParMicro cible = hit.transform.gameObject.GetComponent<EnregistrableParMicro>();
            if (cible && cible != this.cibleActuelle)
            {
                if (this.nouvelleCible){
                    this.nouvelleCible.SortiePreSelection();
                }
                
                this.nouvelleCible = cible;
                this.nouvelleCible.PreSelectionner();
            }
        }
        //pas de collision avec le rayon
        else if (this.nouvelleCible)
        {
            this.nouvelleCible.SortiePreSelection();
            this.nouvelleCible = null;
        }
    }
}
