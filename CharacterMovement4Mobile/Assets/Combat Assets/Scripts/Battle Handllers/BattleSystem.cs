using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public GameObject BugPrefab;
    public GameObject SlimePrefab;
    public GameObject BlobPrefab;
    public GameObject CommonEnemyPrefab;
    public GameObject EyeballPrefab;
    public GameObject GoblinPrefab;
    public GameObject GolemPrefab;

    public Button[] options;

    public Image backgroundImg;

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
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private TextMeshProUGUI playerName, enemyName;
  

    public GameObject QandA;

    void Start()
    {
        if(charData.stageOneProgress >= 4)
        {
            backgroundImg.sprite = Resources.Load<Sprite>("Combat Characters/Background/Forest_Battle_Scene");
        }else
        {
            backgroundImg.sprite = Resources.Load<Sprite>("Combat Characters/Background/First Level Background");
        }
        state = BattleHandler.START;
        StartCoroutine(setupBattle());
    }

    IEnumerator setupBattle()
    {
        PopupMessage.SetActive(false);
        PopupMessage2.SetActive(false);
        QandA.SetActive(false);

        playerName.text = charData.charName;
        enemyName.text = charData.enemyName;

        // PLAYER GUI
        GameObject PlayerGO;
        if (charData.charGender == "Female")
        {
            PlayerGO = Instantiate(FemalePrefab, PlayerPostion);
            PlayerStats = PlayerGO.GetComponent<Stats>();
            PlayerAnim = PlayerGO.GetComponentInChildren<Animator>();
        }
        else
        {
            PlayerGO = Instantiate(MalePrefab, PlayerPostion);
            PlayerStats = PlayerGO.GetComponent<Stats>();
            PlayerAnim = PlayerGO.transform.GetComponentInChildren<Animator>();
        }

        // ENEMY GUI
        if(charData.enemyName == "Slime")
        {
            GameObject EnemyGo = Instantiate(SlimePrefab, EnemyPostion);
            EnemyStats = EnemyGo.GetComponent<Stats>();
            EnemyAnim = EnemyGo.transform.GetComponentInChildren<Animator>();
        }
        else if(charData.enemyName == "Bug")
        {
            GameObject EnemyGo = Instantiate(BugPrefab, EnemyPostion);
            EnemyStats = EnemyGo.GetComponent<Stats>();
            EnemyAnim = EnemyGo.transform.GetComponentInChildren<Animator>();
        }
        else if(charData.enemyName == "BigBlob")
        {
            GameObject EnemyGo = Instantiate(BlobPrefab, EnemyPostion);
            EnemyStats = EnemyGo.GetComponent<Stats>();
            EnemyAnim = EnemyGo.transform.GetComponentInChildren<Animator>();
        }
        else if (charData.enemyName == "Eyeball")
        {
            GameObject EnemyGo = Instantiate(EyeballPrefab, EnemyPostion);
            EnemyStats = EnemyGo.GetComponent<Stats>();
            EnemyAnim = EnemyGo.transform.GetComponentInChildren<Animator>();
        }
        else if (charData.enemyName == "Goblin")
        {
            GameObject EnemyGo = Instantiate(GoblinPrefab, EnemyPostion);
            EnemyStats = EnemyGo.GetComponent<Stats>();
            EnemyAnim = EnemyGo.transform.GetComponentInChildren<Animator>();
        }
        else if (charData.enemyName == "Golem")
        {
            GameObject EnemyGo = Instantiate(GolemPrefab, EnemyPostion);
            EnemyStats = EnemyGo.GetComponent<Stats>();
            EnemyAnim = EnemyGo.transform.GetComponentInChildren<Animator>();
        }
        else
        {
            GameObject EnemyGo = Instantiate(CommonEnemyPrefab, EnemyPostion);
            EnemyStats = EnemyGo.GetComponent<Stats>();
            EnemyAnim = EnemyGo.transform.GetComponentInChildren<Animator>();
        }

        playerHUD.HUD(PlayerStats);
        EnemyHUD.HUD(EnemyStats);


        yield return new WaitForSeconds(1f);

        state = BattleHandler.PLAYERTURN;
        
        PlayerTurn();
         
    }

    private void OnEnable()
    {
        
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
            // IF LOST
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
            charData.stageOneProgress++;
            EnemyAnim.SetTrigger("EnemyDeath");
            addEnemyDefeated(charData.enemyName);
            charData.isWin = true;
        } 
        else if(state == BattleHandler.LOST)
        {
            PopupMessage2.SetActive(true);
            PlayerAnim.SetTrigger("DeathAnimation");
            PlayerLost();
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

    private void PlayerLost()
    {
        charData.charHealth = 100;
        charData.playerPosition = new Vector3(0, 0, 0);
        charData.QnA = quizManager.QnA;

        if(charData.enemiesDefeated.Count < 4)
        {
            // STAGE 1 RESTART
            charData.enemiesDefeated.Clear();
            charData.stageOneProgress = 0;
        }
        else if(charData.enemiesDefeated.Count >= 4)
        {
            // STAGE 2 RESTART
            if(charData.enemiesDefeated.Contains("Goblin")) charData.enemiesDefeated.Remove("Goblin");
            if (charData.enemiesDefeated.Contains("Golem")) charData.enemiesDefeated.Remove("Golem");
            if (charData.enemiesDefeated.Contains("Eyeball")) charData.enemiesDefeated.Remove("Eyeball");
            charData.stageOneProgress = 4;
        }
    }

}
