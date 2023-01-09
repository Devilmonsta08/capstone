using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public CharacterDatabase charDB;
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public TextMeshProUGUI QuestionTxt;


    private void Start() 
    {
        charDB.QnA = QnA;
        generateQuestion();
    }

    public void Wrong()
    {
        //QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }
    public void Correct()
    {
        charDB.QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = charDB.QnA[currentQuestion].Answers[i];

            if (charDB.QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }


    void generateQuestion()
    {
        if(charDB.QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, charDB.QnA.Count);

            QuestionTxt.text = charDB.QnA[currentQuestion].Question;
            SetAnswers();
        }
        else 
        {
            Debug.Log("Out of Question");
        }
    }
}
