using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    [SerializeField] private float _boostAttack = 1.2f;
    
    private GameObject _currentEnemyPosition;
    private GameObject _currentEnemyGameObject;
    private EnemyStats _currentEnemy;
    private EnemyManager _enemyManager;
    private AttackScript _attackScript;
    private int _nbTurnSA;
    private SpellManager _spellManager;
    
    public GameObject CurrentEnemyPosition
    {
        get => _currentEnemyPosition;
        set => _currentEnemyPosition = value;
    }

    public GameObject CurrentEnemyGameObject
    {
        get => _currentEnemyGameObject;
        set => _currentEnemyGameObject = value; 
    }

    public EnemyStats CurrentEnemy
    {
        get => _currentEnemy;
        set => _currentEnemy = value;
    }
    
    public void EnemyTurn()
    {
        CurrentEnemy = ChoseEnemy();
        //Attaque chargée
        if(_nbTurnSA == 3)
        {
            if(_attackScript.Player.GetComponentInChildren<PlayerStats>().player.playerName == "Gray" && _spellManager.isInGuard == true)
            {
                _attackScript.AttackEnemyRiposte(CurrentEnemy, _boostAttack);
                
                CurrentEnemy.enemy.currentAnimator.SetTrigger("AttackStrong");
                
                _nbTurnSA = 0;
            } 
            else 
            {
                _attackScript.AttackEnemy(CurrentEnemy, _boostAttack);
                
                CurrentEnemy.enemy.currentAnimator.SetTrigger("AttackStrong");
                
                _nbTurnSA = 0;                
            }    
        }
        else
        {
            switch(Random.Range(0,2))
            {
                case 0:
                {
                    //Attaque
                    if(_attackScript.Player.GetComponentInChildren<PlayerStats>().player.playerName == "Gray" && _spellManager.isInGuard == true)
                    {
                        _attackScript.AttackEnemyRiposte(CurrentEnemy, 1f);
                        
                        CurrentEnemy.enemy.currentAnimator.SetTrigger("Attack");
                        
                        _nbTurnSA++;
                    } 
                    else 
                    {
                        _attackScript.AttackEnemy(CurrentEnemy, 1f);
                        
                        CurrentEnemy.enemy.currentAnimator.SetTrigger("Attack");
                        
                        _nbTurnSA++;
                    }
                    break;
                }
                case 1:
                {
                    //Defense
                    CurrentEnemy.enemy.defense += 100;
                    CurrentEnemy.enemy.isInDefense = true;
                    
                    CurrentEnemy.enemy.currentAnimator.SetTrigger("Defense");
                    
                    _nbTurnSA++;
            
                    if(_attackScript.Player.GetComponentInChildren<PlayerStats>().player.playerName == "Gray") 
                    {
                        _attackScript.Player.GetComponentInChildren<Animator>().SetTrigger("!EnemyAtk");
                    }
                    break;
                }
            }
        }
    }
    public void EnemyFirstTurn()
    {
        CurrentEnemy = ChoseEnemy();
        
        if(CurrentEnemy.enemy.dead)
        {
            ChoseEnemy();
        }
        else
        {
            //Attaque chargée
            if(_nbTurnSA == 3)
            {
                _attackScript.AttackEnemyRiposte(CurrentEnemy, _boostAttack);
                
                CurrentEnemy.enemy.currentAnimator.SetTrigger("AttackStrong");
                
                _nbTurnSA = 0;
            }
            else
            {
                switch(Random.Range(0,2))
                {
                    case 0:
                    {
                        //Attaque
                        _attackScript.AttackEnemy(CurrentEnemy, 1f);
                        
                        CurrentEnemy.enemy.currentAnimator.SetTrigger("Attack");
                        
                        _nbTurnSA++;
                        
                        break;
                    }
                    case 1:
                    {
                        //Defense
                        CurrentEnemy.enemy.defense += 100;
                        CurrentEnemy.enemy.isInDefense = true;
                        
                        CurrentEnemy.enemy.currentAnimator.SetTrigger("Defense");
                        
                        _nbTurnSA++;
                        
                        break;
                    }
                }
            }
        }
    }

    private EnemyStats ChoseEnemy()
    {
        int _enemyRandom = Random.Range(0, _enemyManager.EnemyList.Count);
        CurrentEnemyGameObject = _enemyManager.EnemyList[_enemyRandom].gameObject;
        EnemyStats _enemyAtk = _enemyManager.EnemyList[_enemyRandom];
        CurrentEnemyPosition = _enemyManager.EmplacementEnemyArray[_enemyRandom];
        
        if(_enemyAtk.enemy.health <= 0)
        {
            return ChoseEnemy();
        }
        
        else 
        {
            return _enemyAtk;
        }               
    }

    private void Awake() 
    {
        _spellManager = FindObjectOfType<SpellManager>();
        _enemyManager = FindObjectOfType<EnemyManager>();
        _attackScript = FindObjectOfType<AttackScript>();
    } 
}
