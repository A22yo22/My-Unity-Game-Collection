using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SavingCS
{
    public static void SaveData(NNet bData1, CarController bData2, GeneticManager bData3)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Data.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        SavingData data = new SavingData(bData1, bData2, bData3);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    internal static void SaveData(object bData3)
    {
        throw new NotImplementedException();
    }

    public static SavingData LoadData()
    {
        string path = Application.persistentDataPath + "/Data.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SavingData date = formatter.Deserialize(stream) as SavingData;
            stream.Close(); 

            return date;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
}
