using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerSpawner : MonoBehaviour
{
    public CharacterDatabase characterDB;

	public SpriteRenderer artworkSprite;

    private int selectedOption = 0;

    [SerializeField] private SaveLoad saveLoad;
    [SerializeField] private Transform characterPosition;

    private void OnApplicationQuit()
    {
        saveLoad.Save();
    }

    private void OnDisable()
    {
        saveLoad.Save();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        if(!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else 
        {
            Load();
        }
        
        UpdateCharacter(selectedOption);

        if(characterDB.charGender == "Female")
        {
            artworkSprite.sprite = Resources.Load<Sprite>("Characters/GirlCharacter/Female Sprite Char");
        }else
        {
            artworkSprite.sprite = Resources.Load<Sprite>("Characters/BoyCharacter/Man Sprite Char");
        }

        LoadData();
    }

    private void LoadData()
    {
        if(characterDB.isLoad)
        {
            saveLoad.Load();
        }
    }

    private void UpdateCharacter(int selectedOption)
	{
		Character character = characterDB.GetCharacter(selectedOption);
		artworkSprite.sprite = character.characterSprite;
	}

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}
