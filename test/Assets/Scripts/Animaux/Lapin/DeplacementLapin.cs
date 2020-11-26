using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//cette classe implémente l'interface EnregistrementAuMetronome pour pouvoir régair aux variations du métronome
public class DeplacementLapin : MonoBehaviour
{
    private Rigidbody rb;
    private NavMeshAgent agent;
    public GestionnaireADSR enveloppeBlendShape;
    private SkinnedMeshRenderer skinnedMeshRenderer;

    //animation
    private Animator anim;
    private int vitesseHash = Animator.StringToHash("Vitesse");

    private void Awake()
    {
        this.rb = GetComponent<Rigidbody>();
        this.agent = GetComponent<NavMeshAgent>();
        this.skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer> ();
    }

    private void Start() {

        this.anim = GetComponent<Animator>();

        this.agent.speed = 16;

        //enregistrer à l'enveloppe
        this.enveloppeBlendShape.EnregistrerDoux(Animer);
    }

    private void Update() {
        //update animator
        this.anim.SetFloat(vitesseHash, this.agent.velocity.magnitude);
    }




    //met le lapin en mouvement versla destination, il s'arrête dès qu'il rentre dans le rayonMin autour de cette destination
    public void BougerVers(Vector3 destination, float rayonMin)
    {
        //calcul direction
        Vector3 direction = (this.transform.position-destination);

        //sqrMagnitude renvoie le carré de la distance, plus optimisé
        if (direction.sqrMagnitude <= (rayonMin * rayonMin))
        {
            //arrete le déplacement
            this.Stop();
            


        }
        else
        {
            //bouge le lapin
            this.agent.isStopped = false;
            this.agent.SetDestination(destination);
        }
    }

    public void Animer(float valeur)
    {
        if (true)
        {
            for (int i = 0; i<9; i++)
                skinnedMeshRenderer.SetBlendShapeWeight (i, valeur *100);
        }         
    }

    public void Stop() {
        
        this.agent.isStopped = true;
        this.rb.velocity = Vector3.zero;
        this.rb.angularVelocity = Vector3.zero;
    }

}
