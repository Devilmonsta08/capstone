using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int stageOneProgress;

    public string charName;
    public string charGender;
    public int charHealth;

    public Character[] character;
    public float[] playerPosition;
    public string enemyName;
    public bool isWin;

    public List<string> enemiesDefeated;

    public List<QuestionAndAnswer> QnA;

    public GameData(CharacterDatabase charDB)
    {
        stageOneProgress = charDB.stageOneProgress;

        charName = charDB.charName;
        charGender = charDB.charGender;
        charHealth = charDB.charHealth;

        playerPosition = new float[3];
        playerPosition[0] = charDB.playerPosition.x;
        playerPosition[1] = charDB.playerPosition.y;
        playerPosition[2] = charDB.playerPosition.z;

        enemiesDefeated = charDB.enemiesDefeated;
        QnA = charDB.QnA;
    }
}
