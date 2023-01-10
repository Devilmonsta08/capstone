using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResult : MonoBehaviour
{
    [SerializeField] private CharacterDatabase charDB;
    public void exitCombat()
    {
        if(charDB.stageOneProgress == 4)
        {
            SceneManager.LoadScene(6);
        }else
        {
            SceneManager.LoadScene(4);
        }
    }
}
