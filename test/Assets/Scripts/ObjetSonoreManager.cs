using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetSonoreManager : MonoBehaviour
{

    //liste d'ObjetSonore
    private List<ObjetSonore> objetsSonores;
    //méronome
    private GameObject metronome;

 

    void Awake()
    { 
        this.objetsSonores = new List<ObjetSonore>();
        this.metronome = GameObject.Find("Metronome");
    }


    //ajoute un objet sonore à  la liste
    public void AddObjetSonore(ObjetSonore obj)
    {
        this.objetsSonores.Add(obj);
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.objetsSonores.Count);
        foreach (ObjetSonore obj in this.objetsSonores)
        {
            //méthode à appliquer à tous les objets sonores...
        }
    }

}
