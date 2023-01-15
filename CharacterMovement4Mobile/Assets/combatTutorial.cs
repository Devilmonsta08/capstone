using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatTutorial : MonoBehaviour
{
    [SerializeField] private CharacterDatabase charDB;
    [SerializeField] private GameObject tutorialPanel;

    private void OnEnable()
    {
        if (charDB.combatTutorial)
        {
            gameObject.SetActive(false);
        }
    }

    public void OneTutorial()
    {
        charDB.combatTutorial = true;
        gameObject.SetActive(false);
    }
}
