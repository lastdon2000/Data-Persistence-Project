using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public ScoreData GameData = new ScoreData();
    public string Username;

    public static DataManager Instance;

    private static string FILE_DATA = "bestscore.json";


    private void Awake()
    {
        if (Instance != null)
        {
            // this destroy new gameobject created 
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }
    [System.Serializable]
    public class ScoreData
    {
        public int BestScore;
        public string BestUser;

        public bool IsEmpty
        {
            get
            {
                if (string.IsNullOrWhiteSpace(BestUser) || BestScore == 0)
                    return true;
                return false;
            }
        }
    }
    public void SaveData()
    {
        string json = JsonUtility.ToJson(GameData);
        File.WriteAllText(Application.persistentDataPath + FILE_DATA, json);
    }
    public void LoadData()
    {
        string path = Application.persistentDataPath + FILE_DATA;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData = JsonUtility.FromJson<ScoreData>(json);
        }
    }
}
