using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonesHandler : MonoBehaviour
{

  private GameObject activeZone;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (activeZone != null)
      {
        activeZone.GetComponent<Collision>().playSound();
      }
    }

    public void setZone(GameObject zone)
    {
      Debug.Log(zone.name);
      Debug.Log("handler setting the zone...");

      activeZone = zone;
    }

    public void leaveZone(GameObject zone)
    {
      Debug.Log("leaving zone");
      if (activeZone == zone)
      {
        activeZone = null;
      }
    }
}
