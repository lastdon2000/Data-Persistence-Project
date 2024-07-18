using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuSceneHandler : MonoBehaviour
{
    public TMPro.TMP_InputField inputUsername;
    public TMPro.TextMeshProUGUI textBestScore;
    // Start is called before the first frame update
    void Start()
    {
        inputUsername.text = DataManager.Instance.Username;
        UpdateBestScore();        
    }
    void UpdateBestScore()
    {
        var data = DataManager.Instance.GameData;
        if (data.IsEmpty)
            textBestScore.gameObject.SetActive(false);
        else
        {
            textBestScore.text = string.Format("Best Score : {0} : {1}", 
                data.BestScore, data.BestUser);
            textBestScore.gameObject.SetActive(true);
            DataManager.Instance.SaveData();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        string name = inputUsername.text;
        if (string.IsNullOrEmpty(name))
        {
            name = "Guest";
            inputUsername.text = name;
        }
        DataManager.Instance.Username = name;
        SceneManager.LoadScene("main");
    }
    public void Exit()
    {
        DataManager.Instance.SaveData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif        
    }
}
