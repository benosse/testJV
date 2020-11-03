using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/***************************************************************************************
BZ
//Une classe qui enregistre tous les objets sonores du jeu
pour le moment elle ne sert pas à grand chose... mais on en aura peut être besoin plus tard pour éteindre certains objets en focntion de leur distance au joueur par exemple
***************************************************************************************/
public class ObjetSonoreManager : MonoBehaviour
{

    //liste d'ObjetSonore
    private List<ObjetSonore> objetsSonores;


 
    void Awake()
    { 
        this.objetsSonores = new List<ObjetSonore>();
    }



    //ajoute un objet sonore à  la liste
    public void AddObjetSonore(ObjetSonore obj)
    {
        this.objetsSonores.Add(obj);
    }

}
