using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject 
{
	public bool isLoad;
	public int stageOneProgress;

	public string charName;
	public string charGender;
	public int charHealth;

    public Character[] character;
	public Vector3 playerPosition;
	public string enemyName;
	public bool isWin;
	public bool tutorial;

	public List<string> enemiesDefeated;

    public List<QuestionAndAnswer> QnA;
    public List<QuestionAndAnswer> AnsweredQnA;

    private void OnEnable() 
	{
		isWin = false;
		playerPosition = new Vector3(0, 0, 0);
	}

    public int CharacterCount
    {
		get
		{
			return character.Length;
		}
	}
    public Character GetCharacter(int index)
	{
		return character[index];
	}
}
