using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionLoader : MonoBehaviour
{
    void OnEnable() 
    {
        //Specifying sceneName and sceneBuildIndex to load the scene
        SceneManager.LoadScene("CharacterSelection", LoadSceneMode.Single);
    }
}
