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

       
        //crée un préfab pour chaque tree du terrain
        //à terme il faudra sans doute faire des tris en fonction de leurs préfab etc...
        
        
        for (int i = 0; i<data.treeInstanceCount; i++)
        {
            TreeInstance terrainTree = this.data.treeInstances[i];
            GameObject prefab = data.treePrototypes[terrainTree.prototypeIndex].prefab;
            GameObject tree = Instantiate(prefab, this.transform.position + Vector3.Scale(terrainTree.position, this.data.size), Quaternion.Euler(new Vector3(0,Mathf.Rad2Deg * terrainTree.rotation,0)), gameObject.transform);

            //enregistre le tree à la bonne enveloppe
            tree.GetComponent<DeplacementBle>().SetEnveloppe(this.enveloppe);
        }
        

         //cache la  végétation du terrain
        gameObject.GetComponent<Terrain>().drawTreesAndFoliage = false;
        
        
    }

    
}
