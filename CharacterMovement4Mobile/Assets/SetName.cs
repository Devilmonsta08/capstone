using TMPro;
using UnityEngine;

public class SetName : MonoBehaviour
{
    [SerializeField] CharacterDatabase charDB;
    private TextMeshProUGUI dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText = GetComponent<TextMeshProUGUI>();
        dialogueText.text = dialogueText.text.Replace("@name", charDB.charName);
    }
}
