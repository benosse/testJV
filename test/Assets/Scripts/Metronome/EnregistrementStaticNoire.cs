using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Une interface qui décrit les méthodes qu'un objet doit implémenter pour pouvoir s'enregistrer auprès du métronome.
public interface EnregistrementStaticNoire
{
    //la méthode appelée par le métronome quand il change de mesure
    void ChangementDeStaticNoire(int staticNoire);
    
}
