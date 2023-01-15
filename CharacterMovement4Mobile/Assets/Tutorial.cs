using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private CharacterDatabase charDB;
    [SerializeField] private GameObject tutorialPanel;

    private void OnEnable()
    {
        if(charDB.tutorial)
        {
            gameObject.SetActive(false);
        }
    }

    public void OneTutorial()
    {
        charDB.tutorial = true;
        gameObject.SetActive(false);
    }
}
