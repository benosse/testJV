using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//cette classe implémente l'interface EnregistrementAuMetronome pour pouvoir régair aux variations du métronome
public class MoveLapin : MonoBehaviour, EnregistrementStaticNoire
{
    public float speed;
    public float jumpForce;

    private Vector3 direction;
    private Rigidbody rb;

    private int rythme;


    void Start()
    {
        this.rb = GetComponent<Rigidbody>();

        this.speed = 4f;
        this.jumpForce = 1f;
        this.direction = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        this.rythme = (int)Random.Range(0,4);

        //on s'enregistre auprès du métronome pour recevoir des updates quand la mesure change
        GameObject metronome = GameObject.Find("Metronome");
        metronome.GetComponent<Metronome>().EnregistrerStaticNoire((EnregistrementStaticNoire)this);
    }

    //déplacement du lapin
    void Update()
    {
        rb.AddForce(this.direction * this.speed, ForceMode.Force);
    }

    void Jump()
    {
        //saute
        rb.AddForce(new Vector3(0, 1, 0) * this.jumpForce, ForceMode.Impulse);
        //change la direction
        this.direction = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
    }


    //méthode appelée par le métronome à chaque changement de mesure
    public void ChangementDeStaticNoire(int staticNoire)
    {
        //Debug.Log("lapin noire: " + staticNoire);
        if (this.rythme == staticNoire)
        {
            this.Jump();
        }      
    }
}
