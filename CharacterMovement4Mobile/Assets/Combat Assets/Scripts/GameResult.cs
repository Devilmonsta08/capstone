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
            charDB.isLoad = false;
            charDB.playerPosition = new Vector3(0, 0, 0);
            SceneManager.LoadScene(6);
        }else if (charDB.stageOneProgress > 4)
        {
            SceneManager.LoadScene(7);
        }else
        {
            SceneManager.LoadScene(4);
        }
    }
}
