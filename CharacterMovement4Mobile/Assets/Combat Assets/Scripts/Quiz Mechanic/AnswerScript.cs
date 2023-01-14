using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public BattleSystem battleSystem;
     public Text TurnTextDialogue;

    
    public void Answer()
    {
        if(isCorrect)
        {
           TurnTextDialogue.text = "Your Answer is Correct";
            Debug.Log("Answer Correct");
            quizManager.Correct();
            battleSystem.PlayerAttack();
        } else 
        {
            TurnTextDialogue.text = "Your Answer is Wrong";
            Debug.Log("Answer Wrong");
            quizManager.Wrong();
            battleSystem.EnemyTurn();
        }
    }
}
