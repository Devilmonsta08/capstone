using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResult : MonoBehaviour
{
    public void exitCombat()
    {
        SceneManager.LoadScene(4);
    }
}
