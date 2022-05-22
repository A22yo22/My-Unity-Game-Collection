using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SavingData
{
    public float saveFitness;
    public float Savebiases;
    public float[] position;

    public SavingData (NNet Data1, CarController Data2, GeneticManager Data3)
    {
        saveFitness = Data1.fitness;
        Savebiases = Data1.biases[1];

        position = new float[3];
        position[0] = Data2.transform.position.x;
        position[1] = Data2.transform.position.z;
        position[2] = Data2.transform.position.y;

    }

    public void SavePlayer()
    {
        S
    }

}
