using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField] private GameObject _rayon;
    [SerializeField] private float _mulUp = 1.2f;
    [SerializeField] private float _mulDown = 0.8f;
    [SerializeField] private float _mulNeutre = 1f;

    private GameObject _player;
    private float _playerAtk;
    private float _playerDef;
    private float _enemyDefense;
    private float _enemyAttack;
    private float _damageModifier;
    private float _damage;
    private TurnManager _turnManager;
    private float _damageModificator = 1;
    private float _damageModificatorEnemy = 1;
    
    public GameObject Player
    {
        get => _player;
        set => _player = value;
    }
    
    public float DamageModificator
    {
        get => _damageModificator;
        set => _damageModificator = value;
    }
    
    public float DamageModificatorEnemy
    {
        get => _damageModificatorEnemy;
        set => _damageModificatorEnemy = value;
    }

    public GameObject Rayon
    {
        get => _rayon;
    }
    
    public void Attack(EnemyStats enemy)
    {
        _playerAtk = Player.GetComponentInChildren<PlayerStats>().player.attack;
        _enemyDefense = enemy.enemy.defense;

        if(_turnManager.PA > 0)
        {
            switch(Player.GetComponentInChildren<PlayerStats>().player.typeArmes)
            {
                case TypeArme.Autre:
                    CalculDmgAlly(enemy, _mulNeutre);
                    break;
                case TypeArme.Ciseaux:
                    switch(enemy.enemy.type)
                    {
                        case MonsterType.Vegetal:
                            CalculDmgAlly(enemy, _mulUp);
                            break;
                        case MonsterType.Mineral:
                            CalculDmgAlly(enemy, _mulDown);
                            break;
                        case MonsterType.Animal:
                            CalculDmgAlly(enemy, _mulNeutre);
                            break;
                    }
                    break;
                case TypeArme.Pioche:
                    switch(enemy.enemy.type)
                    {
                        case MonsterType.Vegetal:
                            CalculDmgAlly(enemy, _mulNeutre);
                            break;
                        case MonsterType.Mineral:
                            CalculDmgAlly(enemy, _mulUp);
                            break;
                        case MonsterType.Animal:
                            CalculDmgAlly(enemy, _mulDown);
                            break;
                    }
                    break;
                case TypeArme.Marteau:
                    switch(enemy.enemy.type)
                    {
                        case MonsterType.Vegetal:
                            CalculDmgAlly(enemy, _mulDown);
                            break;
                        case MonsterType.Mineral:
                            CalculDmgAlly(enemy, _mulNeutre);
                            break;
                        case MonsterType.Animal:
                            CalculDmgAlly(enemy, _mulUp);
                            break;
                    }
                    break;
            }
        }
    }

    public GameObject MajAtk()
    {
        return GameObject.FindGameObjectWithTag("MajAtk");
    }

    public void AttackEnemyRiposte(EnemyStats enemy, float buff)
    {
        _enemyAttack = enemy.enemy.attack;
        _playerDef = Player.GetComponentInChildren<PlayerStats>().player.defense;
        CalculRipostDmgEnemy(enemy, buff);
    }

    public void LevelUP(int level)
    {
        Player.GetComponentInChildren<PlayerStats>().player.Level_up_stat(level);
    }
    
    public void AttackEnemy(EnemyStats enemy, float buff)
    {
        _enemyAttack = enemy.enemy.attack;
        _playerDef = Player.GetComponentInChildren<PlayerStats>().player.defense;
        CalculDmgEnemy(buff);
    }

    private void CalculDmgAlly(EnemyStats enemy, float affinity)
    {
        enemy.gameObject.GetComponentInChildren<Animator>().SetTrigger("Hurt");
        _damage = _playerAtk*(100/(_enemyDefense + 100))*affinity;
        _damageModifier = _damage * DamageModificator;
        Debug.Log(_damageModifier);
        _turnManager.PA = 0;
        enemy.enemy.TakeDmg(_damageModifier);
    }
    
    private void CalculRipostDmgEnemy(EnemyStats enemy, float buff)
    {
        Player.GetComponentInChildren<Animator>().SetTrigger("EnnemiAtk");
        _damage = (_enemyAttack*(100/(_playerDef + 100)));
        _damageModifier = ((_damage * buff) * DamageModificatorEnemy) * .8f;
        Player.gameObject.GetComponentInChildren<PlayerStats>().player.TakeDmg(_damageModifier);
        CalculRiposteDmg(enemy);
    }
    
    private void CalculRiposteDmg(EnemyStats enemy)
    {
        
        float enemyDefTemp = enemy.enemy.defense;
        float playerAtkTemp = Player.GetComponentInChildren<PlayerStats>().player.attack;
        _damage = playerAtkTemp*(100/(enemyDefTemp + 100));
        _damageModifier = _damage * DamageModificator * .6f;
        enemy.enemy.TakeDmg(_damageModifier);
    }
    
    private void CalculDmgEnemy(float buff)
    {
        _damage = (_enemyAttack*(100/(_playerDef + 100)));
        _damageModifier = (_damage * buff) * DamageModificatorEnemy;
        Debug.Log(_damageModifier);
        Player.gameObject.GetComponentInChildren<PlayerStats>().player.TakeDmg((int)_damageModifier);
    }

    private void Update() 
    {
        Player = FindObjectOfType<ChosePlayer>().Player;
    }

    private void Start() 
    {
        Player = FindObjectOfType<ChosePlayer>().Player;
    }

    private void Awake() 
    {
        _turnManager = FindObjectOfType<TurnManager>();
    }
}