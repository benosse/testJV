/*
Si une audioLibe veut être enregistrable par un micro, elle doit implémenter cette interface avec notamment
Cloner() pour se cloner dans l'objet enregistreur, avec ses enveloppes et sa fréaquence par ex.
Supprimer() pour se détruire de l'objet enregistreur
*/

using UnityEngine;
using System.Collections;

public interface IGestionnaireAudioLib
{
    //on peut cloner l'audiolib
    void Cloner(GameObject cible);

    //on peut détruire l'audioLib
    void Supprimer(GameObject cible);

    //on peut changer la fréquence
    void SetFrequence(float frequence);
}
