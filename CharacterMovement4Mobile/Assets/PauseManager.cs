using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private SaveLoad saveLoad;
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        saveLoad.Save();
    }

    public void QuitGame()
    {
        Application.Quit();
        saveLoad.Save();
    }
}
