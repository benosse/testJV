using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Ballon : MonoBehaviour
{

    //L'enveloppe pur gérer l'animation
    public Enveloppe enveloppeAnimation;
    //public Env1 enveloppeAnimation;

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
   
        blendShapeCount = skinnedMesh.blendShapeCount;

        //enregistrement auprès de l'enveloppe
        if (enveloppeAnimation != null)
        {
            enveloppeAnimation.EnregistrerDoux(Animation);
        }
    }

    //déplacement du lapin
    void Update()
    {
  
    }
  
    public void Animation(float valeur)
    {
        blendOne=valeur*100;
        skinnedMeshRenderer.SetBlendShapeWeight (0, blendOne);

    }

    /*public static float map( float value, float leftMin, float leftMax, float rightMin, float rightMax )
    {
        return rightMin + ( value - leftMin ) * ( rightMax - rightMin ) / ( leftMax - leftMin );
        }*/


}
