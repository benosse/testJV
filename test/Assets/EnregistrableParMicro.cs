using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
BZ
composant à mettre à un objet pour qu'il soit enregistrable par un micro
*/
public class EnregistrableParMicro : MonoBehaviour
{
    private TextMesh texte;

    private void Awake() {
        
    }

    private void Start() {
        //tmp : on ajoute un textmesh pour preview
        this.texte = gameObject.AddComponent(typeof(TextMesh)) as TextMesh;
        this.texte.characterSize = 0.01f;
    }


    //méthode appelée quand un micro est à portée
    public void PreSelectionner()
    {
        //this.texte.text = "enregistrer";
    }

    //methode appelée quand un micro est en train d'enregistrer l'objet
    public void Enregistrer()
    {

    }

    //méthode qui s'active quand l'objet n'est plus en présence d'un micro
    public void SortieDuMicro()
    {
        this.texte.text = "";
    }
}
