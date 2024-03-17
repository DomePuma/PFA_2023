using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int PA
    {
        get => _pA;
        set => _pA = value;
    }
    
    private int _pA = 0;  
    private bool _firstTurnPass = false;
    
    [SerializeField] private GameObject uiPlayer;
    
    private EnemyAction enemyAction;
    private EnemyManager enemyManager;
    private TransfereData transfereData;
    private AttackScript attackScript;
    private PlayerStats[] playerStats;
    private EnemyStats[] enemyStats;
    private ChosePlayer chosePlayer;
    private bool hasEnemyAtk = false;

    [Header("Paramètres des buff d'attaque")]
    public bool hasAtkBuff;
    public int atkBuffCooldown;
    [SerializeField] float atkBuffPower;

    [Header("Paramètres des buffs de defense")]
    public bool hasDefBuff;
    public int defBuffCooldown;
    [SerializeField] float defBuffPower;
    
    public void PassTurn()
    {
        CheckEnemyDeath();
        
        if(enemyManager.EnemyRemainingCount == 0)
        {
            enemyManager.EndFight();
        }
        else
        {
            if(transfereData.enemyStartFight)
            {
                uiPlayer.SetActive(false);
                enemyAction.EnemyFirstTurn();
                hasEnemyAtk = true;
                transfereData.enemyStartFight = false;
            
            }
            else
            {
                uiPlayer.SetActive(false);
                enemyAction.EnemyTurn();
                hasEnemyAtk = true;
            } 
        }
    }

    public void EndTurnEnemy()
    {
        uiPlayer.SetActive(true);
        PA = 2;
        hasEnemyAtk = false;
        
        if(!_firstTurnPass) 
        {
            _firstTurnPass = true;
        }

        FindObjectOfType<SpellManager>().isInGuard = false;
        CheckCooldown();
        CheckPlayersDeath();
    }

    private void CheckEnemyDeath()
    {
        for(int i = 0; i < enemyStats.Length; i++)
        {
            if(enemyStats[i].enemy.health <= 0 && enemyStats[i].enemy.dead != true)
            {
                Debug.Log("Dead");
                enemyStats[i].enemy.dead = true;
                //enemyManager.XP += enemyStats[i].enemy.exp;
                enemyManager.EnemyDeath();
            }
        }
    }

    private void CheckCooldown()
    {
        for(int i = 0; i < enemyManager.EnemyList.Count; i++)
        {
            if(enemyManager.EnemyList[i].enemy.isInDefense == true)
            {
                if(enemyManager.EnemyList[i].enemy.hasCooldownDef == false) 
                {
                    enemyManager.EnemyList[i].enemy.cooldownDef = 1;
                    enemyManager.EnemyList[i].enemy.hasCooldownDef = true;
                }
                
                if(enemyManager.EnemyList[i].enemy.isInDefense == true && enemyManager.EnemyList[i].enemy.cooldownDef == 0)
                {
                    enemyAction.CurrentEnemy.enemy.defense -= 100;
                    enemyManager.EnemyList[i].enemy.isInDefense = false;
                    enemyManager.EnemyList[i].enemy.hasCooldownDef = false;
                } 
                
                if(enemyManager.EnemyList[i].enemy.cooldownDef != 0) 
                {
                    enemyManager.EnemyList[i].enemy.cooldownDef--;
                }
                
                if(enemyManager.EnemyList[i].enemy.cooldownDef < 0)
                {
                    enemyManager.EnemyList[i].enemy.cooldownDef = 0;         
                }
            }
        }
        if(hasAtkBuff)
        {
            attackScript.DamageModificator = atkBuffPower;
            
            if(atkBuffCooldown != 0)
            {     
                atkBuffCooldown--;
            }
            else
            {
                hasAtkBuff = false;
                attackScript.DamageModificator = 1;
            }
        }
        
        for(int i = 0; i < playerStats.Length; i++)
        {
            playerStats[i].player.isInvincible = false;
        }
        
        if(hasDefBuff)
        {
            attackScript.DamageModificatorEnemy = defBuffPower;
            
            if(defBuffCooldown != 0)
            {     
                defBuffCooldown--;
            }
            else
            {
                hasDefBuff = false;
                attackScript.DamageModificatorEnemy = 1;
            }
        }
    }
    
    private void CheckPlayersDeath()
    {
        for(int i = 0; i < playerStats.Length; i++)
        {
            if(playerStats[i].player.health <= 0 && playerStats[i].player.dead != true)
            {
                Debug.Log("dead");
                playerStats[i].player.dead = true;
                chosePlayer.PlayerDeath();
            }
        }
    }

    private void Update() 
    {
        if(PA <= 0 && hasEnemyAtk == false)
        {
            uiPlayer.SetActive(false);
        }
    }

    private void Awake() 
    {
        transfereData = FindObjectOfType<TransfereData>();
        playerStats = FindObjectsOfType<PlayerStats>();
        enemyStats = FindObjectsOfType<EnemyStats>();
        enemyManager = FindObjectOfType<EnemyManager>();
        enemyAction = FindObjectOfType<EnemyAction>();
        attackScript = FindObjectOfType<AttackScript>();
        chosePlayer = FindObjectOfType<ChosePlayer>();
    }
}
