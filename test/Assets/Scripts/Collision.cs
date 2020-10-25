using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject handler;

    private void OnTriggerEnter(Collider other)
    {
        handler.GetComponent<ZonesHandler>().setZone(this.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
      handler.GetComponent<ZonesHandler>().leaveZone(this.gameObject);
    }

    public void playSound() {
      Debug.Log("playing sound of" + this.gameObject.name);
    }
}
