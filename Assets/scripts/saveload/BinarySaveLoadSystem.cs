using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class BinarySaveLoadSystem
{
    public static void Save(string filePath, Dictionary<string, object> data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(filePath, FileMode.Create);
        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static Dictionary<string, object> Load(string filePath)
    {
        Dictionary<string, object> data;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(filePath, FileMode.Open);
        data = (Dictionary<string, object>)formatter.Deserialize(fileStream);
        fileStream.Close();
        return data;
    }

    public static void DestroySave(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}