using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalInput : MonoBehaviour
{
    private Animator animator;
    public GameObject animal;
    // Start is called before the first frame update
    void Start()
    {
     animator = GetComponent<Animator>(); 
   
    }

    // Update is called once per frame
    void Update()
    {
     animator.SetFloat("Horizontal",animal.transform.position.x);
      animator.SetFloat("Vertical",animal.transform.position.y);    
    }
}
