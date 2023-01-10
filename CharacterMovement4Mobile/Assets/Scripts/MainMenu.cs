using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private CharacterDatabase charDB;
    [SerializeField] private Button loadBtn;
    private void Start()
    {
        string path = Application.persistentDataPath + "/dunamis.eyy";
        if (File.Exists(path))
        {
            loadBtn.interactable = true;
        }
        else
        {
            loadBtn.interactable = false;
        }
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        charDB.isLoad = false;    
    }

    public void LoadGame()
    {
        GameData data = SaveSystem.LoadData();
        if (data.stageOneProgress == 4)
        {
            SceneManager.LoadScene(7);
        }else
        {
            SceneManager.LoadScene(4);
        }

        charDB.isLoad = true;
    }
    
    public void QuitGame () 
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
