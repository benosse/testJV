using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome
{
    private int metroMesureCount;
    private float periodeNoire;


    private int staticMesure;
    private int staticBlanche;
    private int staticNoire;
    private int staticCroche;
    private int staticDbCroche;
    private int staticTpCroche;
    private int staticQdCroche;


    private int mesure;
    private int blanche;
    private int noire;
    private int croche;
    private int dbCroche;
    private int tpCroche;
    private int qdCroche;




    public void SetMetroMesureCount(float value)
    {
        this.metroMesureCount = (int)value;
    }

    public void SetPeriodeNoire(float value)
    {
        this.periodeNoire = value;
    }

    public void SetStaticMesure(float value)
    {
        this.staticMesure = (int)value;
    }

    //TODO : faire les autres setters


    public int GetMetroMesureCount()
    {
        return this.metroMesureCount;
    }

    public float GetPeriodeNoire()
    {
        return this.periodeNoire;
    }


    public int GetStaticMesure()
    {
        return this.staticMesure;
    }


}
