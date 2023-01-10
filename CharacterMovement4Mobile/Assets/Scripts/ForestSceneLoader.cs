using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForestSceneLoader : MonoBehaviour
{
    void OnEnable()
    {
        //Specifying sceneName and sceneBuildIndex to load the scene
        SceneManager.LoadScene("GameMap2", LoadSceneMode.Single);   
    }
}
