using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum BattleHandler { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;
    
    public Transform PlayerPostion;
    public Transform EnemyPostion;

    Stats PlayerStats;
    Stats EnemyStats;

    public Text TurnTextDialogue;

    public GameObject PopupMessage;
    
    public GameObject PopupMessage2;

    public HudScript playerHUD;
    public HudScript EnemyHUD;
    
    public BattleHandler state;

  

    public GameObject QandA;

    void Start()
    {
        
         state = BattleHandler.START;
         StartCoroutine(setupBattle()); 
    }

    IEnumerator setupBattle()
    {
        PopupMessage.SetActive(false);
        PopupMessage2.SetActive(false);
        QandA.SetActive(false);
        GameObject PlayerGO = Instantiate(PlayerPrefab, PlayerPostion);
        PlayerStats = PlayerGO.GetComponent<Stats>();

        GameObject EnemyGo = Instantiate(EnemyPrefab, EnemyPostion);
        EnemyStats = EnemyGo.GetComponent<Stats>();

        

        
        playerHUD.HUD(PlayerStats);
        EnemyHUD.HUD(EnemyStats);


        yield return new WaitForSeconds(1f);

        state = BattleHandler.PLAYERTURN;
        
        PlayerTurn();
         
    }

    IEnumerator PlayerAttack()
    {
        
        
        bool Attack  = EnemyStats.TakeDamage(PlayerStats.Damage);
        
        EnemyHUD.SetHP(EnemyStats.currentHP);
       
       

        yield return new WaitForSeconds(2f);

        if (Attack)
        {
            state = BattleHandler.WON;
            EndBattle();
        } else
        {
            state = BattleHandler.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        
        QandA.SetActive(false);
        
        
        yield return new WaitForSeconds(1f);
        
        bool Attack = PlayerStats.TakeDamage(EnemyStats.Damage);
        
        playerHUD.SetHP(PlayerStats.currentHP);
        
        yield return new WaitForSeconds(1f);

        if (Attack)
        {
            
            state = BattleHandler.LOST;
            EndBattle();
        } else 
        {
            
            state = BattleHandler.PLAYERTURN;
            PlayerTurn();
        }


    }
    void EndBattle()
    {
        if (state == BattleHandler.WON)
         
        {
            PopupMessage.SetActive(true);
            
            
            
        } else if(state == BattleHandler.LOST)
            
            PopupMessage2.SetActive(true);
        {
    
            
            
        }


    }

    
    void PlayerTurn()
    {
       
        
        QandA.SetActive(true);
    }

      public void Answer()
    {

         

        if (state != BattleHandler.PLAYERTURN)
            return;
            
            StartCoroutine(PlayerAttack());

       
            
        

    }
    

  
}
