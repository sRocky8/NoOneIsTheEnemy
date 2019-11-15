using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class HighScoreKeeper : MonoBehaviour
{
    public static HighScoreKeeper highScoreKeeper;

    public float[] highScores = new float[5];
    public char[] initials = new char[5];
    public Array[] names = new Array[5];

    void Awake()
    {
        if(highScoreKeeper == null)
        {
            DontDestroyOnLoad(gameObject);
            highScoreKeeper = this;
        }
        else if (highScoreKeeper != null)
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream dataFile = File.Create(Application.persistentDataPath + "/NoOneHighScoreDataFile.dat");

        Data data = new Data();

        //Variables
        data.highScores = highScores;
        data.initials = initials;
        data.names = names;

        binaryFormatter.Serialize(dataFile, data);
        dataFile.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/NoOneHighScoreDataFile.dat"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream dataFile = File.Open(Application.persistentDataPath + "/NoOneHighScoreDataFile.dat", FileMode.Open);
            Data data = (Data)binaryFormatter.Deserialize(dataFile);
            dataFile.Close();

            highScores = data.highScores;
            initials = data.initials;
            names = data.names;
        }
    }

    [Serializable]
    class Data
    {
        public float[] highScores = new float[5];
        public char[] initials = new char[5];
        public Array[] names = new Array[5];
    }
}
