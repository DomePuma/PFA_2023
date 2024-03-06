using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    public GameObject currentEnemyPosition;
    public GameObject currentEnemyGameObject;
    public EnemyStats currentEnemy;
    
    [SerializeField] private float attackBooste = 1.2f;
    
    private EnemyManager enemyManager;
    private AttackScript attackScript;
    private int nbTurnSA;
    private SpellManager spellManager;
    private TurnManager turnManager;

    public void EnemyTurn()
    {
        currentEnemy = ChoseEnemy();
        //Attaque chargée
        if(nbTurnSA == 3)
        {
            if(attackScript.Player.GetComponentInChildren<PlayerStats>().player.playerName == "Gray" && spellManager.isInGuard == true)
            {
                attackScript.AttackEnemyRiposte(currentEnemy, attackBooste);
                currentEnemy.enemy.currentAnimator.SetTrigger("AttackStrong");
                nbTurnSA = 0;
                Debug.Log("RiposteAtkFort");
            } 
            else 
            {
                attackScript.AttackEnemy(currentEnemy, attackBooste);
                currentEnemy.enemy.currentAnimator.SetTrigger("AttackStrong");
                nbTurnSA = 0;                
            }    
        }
        else
        {
            switch(Random.Range(0,2))
            {
                case 0:
                {
                    //Attaque
                    if(attackScript.Player.GetComponentInChildren<PlayerStats>().player.playerName == "Gray" && spellManager.isInGuard == true)
                    {
                        attackScript.AttackEnemyRiposte(currentEnemy, 1f);
                        currentEnemy.enemy.currentAnimator.SetTrigger("Attack");
                        nbTurnSA++;
                        Debug.Log("RiposteAtk");
                    } 
                    else 
                    {
                        attackScript.AttackEnemy(currentEnemy, 1f);
                        currentEnemy.enemy.currentAnimator.SetTrigger("Attack");
                        nbTurnSA++;
                    }
                    break;
                }
                case 1:
                {
                    //Defense
                    currentEnemy.enemy.defense += 100;
                    currentEnemy.enemy.isInDefense = true;
                    currentEnemy.enemy.currentAnimator.SetTrigger("Defense");
                    nbTurnSA++;
            
                    if(attackScript.Player.GetComponentInChildren<PlayerStats>().player.playerName == "Gray") 
                    {
                        attackScript.Player.GetComponentInChildren<Animator>().SetTrigger("!EnemyAtk");
                    }
            
                    break;
                }
            }
        }
    }
    public void EnemyFirstTurn()
    {
        currentEnemy = ChoseEnemy();
        
        if(currentEnemy.enemy.dead)
        {
            ChoseEnemy();
        }
        else
        {
            //Attaque chargée
            if(nbTurnSA == 3)
            {
                attackScript.AttackEnemyRiposte(currentEnemy, attackBooste);
                currentEnemy.enemy.currentAnimator.SetTrigger("AttackStrong");
                nbTurnSA = 0;
            }
            else
            {
                switch(Random.Range(0,2))
                {
                    case 0:
                    {
                        //Attaque
                        attackScript.AttackEnemy(currentEnemy, 1f);
                        currentEnemy.enemy.currentAnimator.SetTrigger("Attack");
                        nbTurnSA++;
                        break;
                    }
                    case 1:
                    {
                        //Defense
                        currentEnemy.enemy.defense += 100;
                        currentEnemy.enemy.isInDefense = true;
                        currentEnemy.enemy.currentAnimator.SetTrigger("Defense");
                        nbTurnSA++;
                        break;
                    }
                }
            }
        }
    }

    private EnemyStats ChoseEnemy()
    {
        int enemyRandom = Random.Range(0, enemyManager.enemis.Count);
        currentEnemyGameObject = enemyManager.enemis[enemyRandom].gameObject;
        EnemyStats enemyAtk = enemyManager.enemis[enemyRandom];
        currentEnemyPosition = enemyManager.emplacementEnnemis[enemyRandom];
        if(enemyAtk.enemy.health <= 0)
        {
            return ChoseEnemy();
        }
        else return enemyAtk;
    }

    private void Awake() 
    {
        spellManager = FindObjectOfType<SpellManager>();
        enemyManager = FindObjectOfType<EnemyManager>();
        attackScript = FindObjectOfType<AttackScript>();
        turnManager = FindObjectOfType<TurnManager>();
    } 
}
