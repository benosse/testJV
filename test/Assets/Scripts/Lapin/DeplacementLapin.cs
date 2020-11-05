using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//cette classe implémente l'interface EnregistrementAuMetronome pour pouvoir régair aux variations du métronome
public class DeplacementLapin : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public float acceleration;

    //L'enveloppe pur gérer l'animation
    public Enveloppe enveloppeAnimation;

    private Vector3 direction;
    private Rigidbody rb;


    //tmp pour le déplacement
    private GameObject player;




    void Start()
    {
        this.rb = GetComponent<Rigidbody>();

        this.speed = 4f;
        this.jumpForce = 1f;
        this.direction = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));

        this.player = GameObject.Find("Player");



        //enregistrement auprès de l'enveloppe
        if (enveloppeAnimation)
        {
            enveloppeAnimation.Enregistrer(Animation);
        }
    }

    //déplacement du lapin
    void Update()
    {
        //fuit le joueur
        this.direction = (this.rb.transform.position - this.player.transform.position).normalized;
        this.direction *= Random.Range(1,1.2f);
        rb.AddForce(this.direction * this.speed, ForceMode.Force);
    }



    
    public void Animation(float valeur)
    {

            rb.transform.localScale = new Vector3(1+valeur, 1+valeur, 1+valeur);

    }

}
