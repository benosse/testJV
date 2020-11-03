using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//cette classe implémente l'interface EnregistrementAuMetronome pour pouvoir régair aux variations du métronome
public class MoveLapin : MonoBehaviour, EnregistrementMesure
{
    public float speed;
    public float jumpForce;

    private Vector3 direction;
    private Rigidbody rb;


    void Start()
    {
        this.rb = GetComponent<Rigidbody>();

        this.speed = 4f;
        this.jumpForce = 4f;
        this.direction = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));

        //on s'enregistre auprès du métronome pour recevoir des updates quand la mesure change
        GameObject metronome = GameObject.Find("Metronome");
        metronome.GetComponent<Metronome>().EnregistrerMesure(this);
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
    public void ChangementDeMesure()
    {
        this.Jump();
    }
}
