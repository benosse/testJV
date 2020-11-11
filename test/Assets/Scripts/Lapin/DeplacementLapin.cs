using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//cette classe implémente l'interface EnregistrementAuMetronome pour pouvoir régair aux variations du métronome
public class DeplacementLapin : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public float acceleration;
    public float scaleVal;

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
            enveloppeAnimation.EnregistrerDoux(Animation);
        }
    }

    //déplacement du lapin
    void Update()
    {
        //fuit le joueur
        this.direction = (this.rb.transform.position - this.player.transform.position).normalized;
        this.direction *= Random.Range(1,1.2f);
        rb.AddForce(this.direction * this.speed, ForceMode.Force);
        
        //rb.transform.localScale = new Vector3(1+this.scaleVal, 1+this.scaleVal, 1+this.scaleVal);
    }



    
    public void Animation(float valeur)
    {
        /*float scaledValue = map(valeur, 0.0f, 1.0f, 0.0f, 4.0f);
        rb.transform.localScale = new Vector3(1+scaledValue, 1+scaledValue, 1+scaledValue);
        this.scaleVal = valeur ;*/

<<<<<<< HEAD
        rb.transform.localScale = new Vector3(2f+valeur/2, 2f+valeur/2, 2f+valeur/2);
=======
           // rb.transform.localScale = new Vector3(1+valeur, 1+valeur, 1+valeur);
>>>>>>> XRrig

    }

    public static float map( float value, float leftMin, float leftMax, float rightMin, float rightMax )
    {
        return rightMin + ( value - leftMin ) * ( rightMax - rightMin ) / ( leftMax - leftMin );
        }


}
