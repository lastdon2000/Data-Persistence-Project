using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public SaveData GameData = new SaveData();
    public string Username;

    public static DataManager Instance;

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
    }
    [System.Serializable]
    public class SaveData
    {
        public int BestScore;
    }
}
