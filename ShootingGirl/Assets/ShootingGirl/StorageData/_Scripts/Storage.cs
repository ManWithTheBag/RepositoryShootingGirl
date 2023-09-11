using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Storage : MonoBehaviour
{
    [Header("Storage file property")]
    private string _storagePath;
    private string _storageFiteName = "storageData.json";

    [Header("Storage Data")]
    private int _totalScore;

    public int totalScore { get { return _totalScore; } set { _totalScore = value; } }

    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _storagePath = Path.Combine(Application.persistentDataPath, _storageFiteName);
#else
        _storagePath = Path.Combine(Application.dataPath, _storageFiteName);
#endif

        LoadFromFile();
    }

    private void LoadFromFile()
    {
        if (!File.Exists(_storagePath))
        {
            Debug.Log("Error: StorageData fite not exists");
            return;
        }

        try
        {
            string json = File.ReadAllText(_storagePath);
            StorageData storageData = JsonUtility.FromJson<StorageData>(json);

            _totalScore = storageData.totalScore;
        }
        catch (Exception e)
        {
            Debug.Log("Error: File 'storageData.json' not readed: " + e.Message);
        }
    }


    private void OnApplicationQuit()
    {
        SaveToFile();
    }
    private void OnApplicationPause(bool pause)
    {
        if (Application.platform == RuntimePlatform.Android)
            SaveToFile();
    }

    private void SaveToFile()
    {
        StorageData storageData = new StorageData();
        storageData.totalScore = _totalScore;

        string json = JsonUtility.ToJson(storageData, prettyPrint: true);

        try
        {
            File.WriteAllText(_storagePath, json);
        }
        catch (Exception e)
        {
            Debug.Log("Errpr: File not saved: " + e.Message);
        }
    }
}
