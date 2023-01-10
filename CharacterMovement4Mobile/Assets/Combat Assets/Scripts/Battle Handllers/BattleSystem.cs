using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public enum BattleHandler { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    private Animator PlayerAnim;

    private Animator EnemyAnim;
    public GameObject MalePrefab;
    public GameObject FemalePrefab;
    public GameObject EnemyPrefab;

    public RuntimeAnimatorController MaleController;
    public RuntimeAnimatorController FemaleController;

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

    [SerializeField] private CharacterDatabase charData;

    [SerializeField] private SaveLoad saveLoad;
  

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
        GameObject PlayerGO;
        if (charData.charGender == "Female")
        {
            PlayerGO = Instantiate(FemalePrefab, PlayerPostion);
            PlayerStats = PlayerGO.GetComponent<Stats>();
            PlayerAnim = PlayerGO.GetComponentInChildren<Animator>();
        }else
        {
            PlayerGO = Instantiate(MalePrefab, PlayerPostion);
            PlayerStats = PlayerGO.GetComponent<Stats>();
            PlayerAnim = PlayerGO.transform.GetComponentInChildren<Animator>();
        }

        GameObject EnemyGo = Instantiate(EnemyPrefab, EnemyPostion);
        EnemyStats = EnemyGo.GetComponent<Stats>();
        EnemyAnim = EnemyGo.transform.GetComponentInChildren<Animator>();

        
        playerHUD.HUD(PlayerStats);
        EnemyHUD.HUD(EnemyStats);


        yield return new WaitForSeconds(1f);

        state = BattleHandler.PLAYERTURN;
        
        PlayerTurn();
         
    }

    public void PlayerAttack()
    {
        
        PlayerAnim.SetTrigger("Attacking");
        EnemyAnim.SetTrigger("DamageEnemy");
        bool Attack  = EnemyStats.TakeDamage(PlayerStats.Damage);
        
        EnemyHUD.SetHP(EnemyStats.currentHP);
       
       

        //yield return new WaitForSeconds(2f);

        if (Attack)
        {
            state = BattleHandler.WON;
            EnemyAnim.SetTrigger("EnemyDeath");
            
            EndBattle();
        } else
        {
            state = BattleHandler.PLAYERTURN;
            PlayerTurn();
            //state = BattleHandler.ENEMYTURN;
            //StartCoroutine(EnemyTurn());
        }
    }

    private void addEnemyDefeated(string enemy)
    {
        if(charData.enemiesDefeated == null)
        {
            charData.enemiesDefeated = new List<string> { enemy };
        }else if(!charData.enemiesDefeated.Contains(enemy))
        {
            charData.enemiesDefeated.Add(enemy);
        }
    }

    public void EnemyTurn()
    {
        EnemyAnim.SetTrigger("AttackingEnemy");
        PlayerAnim.SetTrigger("Damage");
        QandA.SetActive(false);
        
        
        //yield return new WaitForSeconds(1f);
        
        bool Attack = PlayerStats.TakeDamage(EnemyStats.Damage);
        
        playerHUD.SetHP(PlayerStats.currentHP);
        
        //yield return new WaitForSeconds(1f);

        if (Attack)
        {
            state = BattleHandler.LOST;
            PlayerAnim.SetTrigger("DeathAnimation");
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
            addEnemyDefeated(charData.enemyName);
            charData.isWin = true;
        } 
        else if(state == BattleHandler.LOST)
        {
            PopupMessage2.SetActive(true);
        }
        saveLoad.Save();
    }

    
    void PlayerTurn()
    {
        QandA.SetActive(true);
    }

    public void Answer()
    {

        if (state != BattleHandler.PLAYERTURN)
            return;
            
            //StartCoroutine(PlayerAttack());    

    }

}
