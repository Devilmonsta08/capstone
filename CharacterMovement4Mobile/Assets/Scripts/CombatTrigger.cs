using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatTrigger : MonoBehaviour
{
    [SerializeField] private CharacterDatabase charData;
    [SerializeField] private Transform player;

    private void OnTriggerEnter2D(Collider2D collisionInfo) 
    {
        Debug.Log(collisionInfo);
        charData.playerPosition = player.position;
        charData.enemyName = gameObject.name;
        SceneManager.LoadScene(5);
    }

    private void OnEnable() 
    {
        if(charData.isWin)
        {
            Destroy(GameObject.Find(charData.enemyName));
        }

        player.position = charData.playerPosition;
    }
}
