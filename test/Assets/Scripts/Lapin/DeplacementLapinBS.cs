﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//cette classe implémente l'interface EnregistrementAuMetronome pour pouvoir régair aux variations du métronome
public class DeplacementLapinBS : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public float acceleration;
    public float scaleVal;

    //L'enveloppe pur gérer l'animation
    public Env0 enveloppeAnimation;

    private Vector3 direction;
    private Rigidbody rb;


    //tmp pour le déplacement
    private GameObject player;

    //blendshape
    int blendShapeCount;
    SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;
    float blendOne = 0f;

    void Awake ()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer> ();
        skinnedMesh = GetComponent<SkinnedMeshRenderer> ().sharedMesh;
        }



    void Start()
    {
        /*this.rb = GetComponent<Rigidbody>();

        this.speed = 4f;
        this.jumpForce = 1f;
        this.direction = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));

        this.player = GameObject.Find("Player");*/

        blendShapeCount = skinnedMesh.blendShapeCount;

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
        //this.direction = (this.rb.transform.position - this.player.transform.position).normalized;
        this.direction *= Random.Range(1,1.2f);
        //rb.AddForce(this.direction * this.speed, ForceMode.Force);
        
        //rb.transform.localScale = new Vector3(1+this.scaleVal, 1+this.scaleVal, 1+this.scaleVal);
    }



    
    public void Animation(float valeur)
    {
        /*float scaledValue = map(valeur, 0.0f, 1.0f, 0.0f, 4.0f);
        rb.transform.localScale = new Vector3(1+scaledValue, 1+scaledValue, 1+scaledValue);
        this.scaleVal = valeur ;*/

        //rb.transform.localScale = new Vector3(1f+valeur, 1f+valeur,1f+valeur);
        blendOne=valeur*100;
        skinnedMeshRenderer.SetBlendShapeWeight (0, blendOne);

    }

    public static float map( float value, float leftMin, float leftMax, float rightMin, float rightMax )
    {
        return rightMin + ( value - leftMin ) * ( rightMax - rightMin ) / ( leftMax - leftMin );
        }


}
