using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dictionary : MonoBehaviour
{
    [SerializeField] private CharacterDatabase charDB;
    [SerializeField] private GameObject textTemplate, NoContentTxt;
    private GameObject g;

    [SerializeField] private TextMeshProUGUI word, classification, definition;

    private void OnEnable()
    {
        if(charDB.AnsweredQnA != null)
        {
            NoContentTxt.SetActive(false);

            for (int i = 0; i < charDB.AnsweredQnA.Count; i++)
            {
                g = Instantiate(textTemplate, transform);
                g.GetComponent<TextMeshProUGUI>().text = charDB.AnsweredQnA[i].Answers[charDB.AnsweredQnA[i].CorrectAnswer - 1];
                g.SetActive(true);
            }

            word.gameObject.SetActive(true);
            classification.gameObject.SetActive(true);
            definition.gameObject.SetActive(true);

            word.text = charDB.AnsweredQnA[0].AnswerWord;
            classification.text = charDB.AnsweredQnA[0].Classification;
            definition.text = charDB.AnsweredQnA[0].Definition;
        }
        else
        {
            word.gameObject.SetActive(false);
            classification.gameObject.SetActive(false);
            definition.gameObject.SetActive(false);

            NoContentTxt.SetActive(true);
        }
    }

    private void OnDisable()
    {
        foreach(Transform words in transform)
        {
            Destroy(transform.gameObject);
        }
    }

    public void ShowDefinition()
    {
        Debug.Log("hello");
        int wordIndex = EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex();
        word.text = charDB.AnsweredQnA[wordIndex].AnswerWord;
        classification.text = charDB.AnsweredQnA[wordIndex].Classification;
        definition.text = charDB.AnsweredQnA[wordIndex].Definition;
    }
}
