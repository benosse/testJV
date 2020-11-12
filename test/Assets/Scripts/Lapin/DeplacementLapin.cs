using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//cette classe implémente l'interface EnregistrementAuMetronome pour pouvoir régair aux variations du métronome
public class DeplacementLapin : MonoBehaviour
{
    private Rigidbody rb;
    public float force;

    private void Awake() {
        this.rb = GetComponent<Rigidbody>();
    }


    public void BougerVers(Vector3 destination)
    {
        //calcul direction
        Vector3 direction = (destination - this.transform.position).normalized;

        //ajout de random
        direction.x += Random.Range (-0.5f, 0.5f);
        direction.z += Random.Range (-0.5f, 0.5f);

        direction.y = 1f;

        rb.AddForce(direction * this.force, ForceMode.Impulse);
    }

}
