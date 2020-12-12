using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
BZ
Les scripts ne s'exécutent pas avec les trees posés via le terrain
Il faut sûrement reconstruire les trees en tant que gameobject et non treeinstance
*/
public class GestionnaireTerrain : MonoBehaviour
{
    public GestionnaireADSR enveloppe;
    private TerrainData data;

    void Start()
    {
        this.data = gameObject.GetComponent<Terrain>().terrainData;
        /*
        for (int i = 0; i<data.treeInstanceCount; i++)
        {
            GameObject prefab = data.treePrototypes[this.data.treeInstances[i].prototypeIndex].prefab;
            Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
        */
        //this.data.SetTreeInstances(new TreeInstance[0], false);
        
    }

    
}
