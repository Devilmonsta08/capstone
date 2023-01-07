using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneLoader : MonoBehaviour
{
    void OnEnable() 
    {
        //Specifying sceneName and sceneBuildIndex to load the scene
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
