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
    // Start is called before the first frame update
    void Start()
    {
        inputUsername.text = DataManager.Instance.Username;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        //var editField = GameObject.Find("EditUsername");
        //var inputUsername = editField.GetComponent<TMPro.TMP_InputField>();

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
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif        
    }
}
