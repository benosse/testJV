using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
BZ 
Déplace l'insecte en utilisant son NavMesh
Gère les animations enutilisant son Animator
*/
public class DeplacementInsecte : MonoBehaviour
{
    private NavMeshAgent agent;

    public float rayonDestination;

    public GestionnaireADSR enveloppe;

    private Rigidbody rb;

    [SerializeField]
    private bool enMouvement;

    //animation
    private Animator anim;
    private int vitesseHash = Animator.StringToHash("Vitesse");

    private void Awake()
    {
        this.rb = GetComponent<Rigidbody>();
        this.agent = GetComponent<NavMeshAgent>();
        this.rayonDestination = 20;
    }

    private void Start()
    {
        this.enveloppe.UpdatePhase += Bouger;
        this.anim = GetComponent<Animator>();
    }

    //utilise update pour vérifier si l'agent a atteint sa destination
    //c'est peut être pas très bon niveau performance
    private void Update()
    {
        //update animator
        //this.anim.SetFloat(vitesseHash, this.agent.velocity.magnitude);

        //stop
        if (this.enMouvement)
        {
            if (!this.agent.pathPending)
            {
                if (
                    this.agent.remainingDistance <=
                    this.agent.stoppingDistance
                )
                {
                    if (
                        !this.agent.hasPath ||
                        this.agent.velocity.sqrMagnitude == 0f
                    )
                    {
                        this.Stop();
                    }
                }
            }
        }
    }

    public void Bouger(float trigger)
    {
        //on lance le déplacement à chaque début d'enveloppe,
        //sinon on arrête le mouvement en cours
        if (trigger != 0)
        {
            this.Stop();
            return;
        }

        Vector3 destination =
            transform.position + Random.onUnitSphere * this.rayonDestination;

        NavMeshHit hit;
        int masque = 1 << NavMesh.GetAreaFromName("InsectesArea");
        NavMesh
            .SamplePosition(destination,
            out hit,
            this.rayonDestination,
            masque);
        destination = hit.position;

        //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube.transform.position = destination;
        //lance le déplacement de l'agent
        this.agent.destination = destination;

        this.Demarrer();
    }

    //la méthode à appeler à chaque fois qu'on se met en mouvement
    public void Demarrer()
    {
        this.agent.isStopped = false;
        this.enMouvement = true;
    }

    //la fonction qu'on appelle à chaque fois que l'on arrête de se déplacer
    public void Stop()
    {
        this.agent.isStopped = true;
        this.rb.velocity = Vector3.zero;
        this.rb.angularVelocity = Vector3.zero;

        this.enMouvement = false;
    }
}
