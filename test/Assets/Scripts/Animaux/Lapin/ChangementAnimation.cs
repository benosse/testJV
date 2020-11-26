using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangementAnimation : MonoBehaviour
{
    private Animator animator;
 
  public   float positionObjet;
   
    void Start()
    {
        animator = this.GetComponent<Animator>();
        Debug.Log(animator);

    }

    // Update is called once per frame
    void Update()
    {
     
        positionObjet = this.transform.position.y;
        animator.SetFloat("Position", positionObjet);
         
       
    
}
}
