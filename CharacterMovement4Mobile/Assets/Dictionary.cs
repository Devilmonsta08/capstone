using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dictionary : MonoBehaviour
{
    [SerializeField] private CharacterDatabase charDB;
    [SerializeField] private GameObject textTemplate, NoContentTxt;
    [SerializeField] private Transform definitionPanel;
    private GameObject g;

    [SerializeField] private TextMeshProUGUI word, classification, definition, example;

    private void OnEnable()
    {
        if (charDB.AnsweredQnA != null && charDB.AnsweredQnA.Any())
        {
            NoContentTxt.SetActive(false);

            for (int i = 0; i < charDB.AnsweredQnA.Count; i++)
            {
                g = Instantiate(textTemplate, transform);
                g.GetComponent<TextMeshProUGUI>().text = charDB.AnsweredQnA[i].AnswerWord;
                g.SetActive(true);
            }

            word.gameObject.SetActive(true);
            classification.gameObject.SetActive(true);
            definition.gameObject.SetActive(true);
            example.gameObject.SetActive(true);

            word.text = charDB.AnsweredQnA[0].AnswerWord;
            classification.text = charDB.AnsweredQnA[0].Classification;
            definition.text = charDB.AnsweredQnA[0].Definition;
            example.text = "<b>Example:</b>\n" + charDB.AnsweredQnA[0].Example;
        }
        else
        {
            word.gameObject.SetActive(false);
            classification.gameObject.SetActive(false);
            definition.gameObject.SetActive(false);
            example.gameObject.SetActive(false);

            NoContentTxt.SetActive(true);
        }
    }

    private void OnDisable()
    {
        foreach (Transform words in transform)
        {
            Destroy(words.gameObject);
        }
    }

    public void ShowDefinition()
    {
        definitionPanel.GetComponent<VerticalLayoutGroup>().enabled = false;
        int wordIndex = EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex();
        word.text = charDB.AnsweredQnA[wordIndex].AnswerWord;
        classification.text = charDB.AnsweredQnA[wordIndex].Classification;
        definition.text = charDB.AnsweredQnA[wordIndex].Definition;
        example.text = "<b>Example:</b>\n" + charDB.AnsweredQnA[wordIndex].Example;

        StartCoroutine(refreshLayout());
    }

    private IEnumerator refreshLayout()
    {
        //LayoutRebuilder.ForceRebuildLayoutImmediate(definitionPanel.GetComponent<RectTransform>());
        //LayoutRebuilder.ForceRebuildLayoutImmediate(definitionPanel.GetChild(0).GetComponent<RectTransform>());
        yield return new WaitForSeconds(0.01f);
        definitionPanel.GetComponent<VerticalLayoutGroup>().enabled = true;
    }

}
