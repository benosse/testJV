using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Micro : MonoBehaviour
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

    //l'audiosource du micro
    private AudioSource audioSource;

    //le mixer du micro et son groupe
    private AudioMixer mixer;
    private AudioMixerGroup master;

    //les snapshots du mixer
    private AudioMixerSnapshot on;
    private AudioMixerSnapshot off;
    private float transition = 0.5f;

    public string nom;



    private void Awake()
    {
        //récupération du mixer et audiosource
        this.mixer = Resources.Load<AudioMixer>(this.nom);
        this.master = mixer.FindMatchingGroups("Master")[0];
        this.on = mixer.FindSnapshot("On");
        this.off = mixer.FindSnapshot("Off");

        this.audioSource = GetComponent<AudioSource>();

        //visualisation du rayon
        this.lineRenderer = gameObject.GetComponent<LineRenderer>();
        this.lineRenderer.SetPosition(0, Vector3.zero );
        this.lineRenderer.SetPosition(1, new Vector3(0, this.distanceMax/this.transform.localScale.x, 0));
        
        this.lineRenderer.startColor = this.couleurEnregistrement;
        this.lineRenderer.endColor = this.couleurEnregistrement;
    }

    private void Start() {
        this.audioSource.outputAudioMixerGroup = this.master;
        this.off.TransitionTo(0f);
    }



    //*****************************************************************************************************
    //EVENEMENTS    
    //e enregistrer, c desenregistrer, j jouer
    //*****************************************************************************************************
    private void gestionEvenements()
    {
        if (Input.GetKeyDown("e"))
        {
            this.Enregistrer();
        }

        if (Input.GetKeyDown("c"))
        {
            Debug.Log("exit");
            this.Desenregistrer();
        }

        if (Input.GetKeyDown("j"))
        {
            this.Jouer();
        }
    }

    public void Enregistrer()
    {
        if (this.nouvelleCible)
        {
            if (this.nouvelleCible == this.cibleActuelle)
            {
                //même cible que précédemment : on ne fait rien
            }
            else{
                //arrête enregistrement de la cible précédente
                if (this.cibleActuelle)
                {
                    this.cibleActuelle.SortieEnregistrement(this.gameObject);
                }
                
                //s'enregistre à la nouvelle cible
                this.cibleActuelle = this.nouvelleCible;
                this.cibleActuelle.Enregistrer(this.gameObject);
            }
        }
    }


    public void Jouer()
    {
        if (this.lectureEnCours)
        {
            this.lectureEnCours = false;
            this.off.TransitionTo(this.transition);
        }
        else
        {
            this.lectureEnCours = true;
            this.on.TransitionTo(this.transition);
        }
    }


    public void Desenregistrer()
    {
        if (this.cibleActuelle)
        {
            this.cibleActuelle.SortieEnregistrement(this.gameObject);
            this.cibleActuelle = null;
        }
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
            if (cible && cible != this.nouvelleCible)
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
