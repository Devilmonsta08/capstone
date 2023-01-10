using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    [SerializeField] private CharacterDatabase charDB;
    [SerializeField] private Transform characterPosition;
    public void Save()
    {
        SaveSystem.SaveData(charDB);
    }

    public void Load()
    {
        GameData data = SaveSystem.LoadData();

        charDB.charName = data.charName;
        charDB.charGender  = data.charGender;

        charDB.enemiesDefeated = data.enemiesDefeated;
        if(SceneManager.GetActiveScene().name == "Game")
        {
            foreach (string enemy in charDB.enemiesDefeated)
            {
                Destroy(GameObject.Find(enemy));
            }
        }

        charDB.playerPosition.x = data.playerPosition[0];
        charDB.playerPosition.y = data.playerPosition[1];
        charDB.playerPosition.z = data.playerPosition[2];

        characterPosition.position = charDB.playerPosition;

        charDB.QnA = data.QnA;
    }
}