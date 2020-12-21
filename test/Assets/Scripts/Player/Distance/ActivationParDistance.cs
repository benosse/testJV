using UnityEngine;


/*BZ
à assigner aux objets qui doivent être désactivas quand trop loin du joueur
verifie deux choses : 
-la collision avec le joueur (il faudra sans doute différentes sphères de collision en fonction des objets)
-la visibilité par rapport à la caméra
*/

public class ActivationParDistance : MonoBehaviour
{
    //si on est dans la zone de procimité du joueur
    protected bool collision = false;


/*
Event controllé par la proximité du joueur
*/
    private void OnTriggerEnter(Collider other) {
        this.collision = true;
        if (!this.enabled)
        {
            Activer();
        }    
    }

    private void OnTriggerExit(Collider other) {
        this.collision = false;
    }

/*
Event contôlé par la caméra et le LOD
*/
    protected virtual void OnBecameInvisible()
    {
        if (!this.collision && this.enabled)
        {
            Desactiver(); 
        }   
    }

    protected virtual void  OnBecameVisible()
    {
        if (!this.enabled)
        {
            Activer();
        }
    }

/*
Active et désactive l'objet (enable)
Si il y a d'autres opérations à faire avant de désactiver l'objet, overrider cette méthode dans les classes enfant
*/
    protected virtual void Activer()
    {
        this.enabled = true;
    }
    protected virtual void Desactiver()
    {
        this.enabled = false;
    }
}
