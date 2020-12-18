using UnityEngine;


/*BZ
à assigner aux objets qui doivent être désactivas quand trop loin du joueur
verifie deux choses : 
-la collision avec le joueur (il faudra sans doute différentes sphères de collision en fonction des objets)
-la visibilité par rapport à la caméra
*/

public class ActivationParDistance : MonoBehaviour
{

    private bool collision = false;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("entrée");
        this.collision = true;
        if (!this.enabled)
        {
            this.enabled = true;
        }    
    }

    private void OnTriggerExit(Collider other) {
        this.collision = false;
        Debug.Log("sortie");
    }

    protected virtual void OnBecameInvisible()
    {
        if (!this.collision && this.enabled)
        {
            this.enabled = false;  
        }   
    }


    protected virtual void  OnBecameVisible()
    {
        if (!this.enabled)
        {
            this.enabled = true;
        }
    }
}
