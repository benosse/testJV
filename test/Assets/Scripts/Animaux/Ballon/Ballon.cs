using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    //L'enveloppe pur gérer l'animation
    public GestionnaireADSR enveloppeAnimation;

    //blendshape
    int blendShapeCount;

    SkinnedMeshRenderer skinnedMeshRenderer;

    Mesh skinnedMesh;

    float blendOne = 0f;

    void Awake()
    {
        this.skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        this.skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
    }

    void Start()
    {
        blendShapeCount = skinnedMesh.blendShapeCount;

        //enregistrement auprès de l'enveloppe
        if (enveloppeAnimation != null)
        {
            enveloppeAnimation.EnregistrerDoux (Animation);
        }
    }



    public void Animation(float valeur)
    {
        blendOne = valeur * 100;
        skinnedMeshRenderer.SetBlendShapeWeight(0, blendOne);
    }

    /*public static float map( float value, float leftMin, float leftMax, float rightMin, float rightMax )
    {
        return rightMin + ( value - leftMin ) * ( rightMax - rightMin ) / ( leftMax - leftMin );
        }*/
}
