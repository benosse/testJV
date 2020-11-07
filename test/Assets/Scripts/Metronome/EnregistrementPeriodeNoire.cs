using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************************************************
BZ
//Une interface qui décrit les méthodes qu'un objet doit implémenter pour pouvoir s'enregistrer auprès du métronome.
***************************************************************************************/

public interface EnregistrementPeriodeNoire 
{
    //la méthode appelée par le métronome quand il change de mesure
    void ChangementDePeriodeNoire(float periode);
    
}
