using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] public EnemyStat enemy = new EnemyStat("");
    [SerializeField] public GameObject selectLight;
    public GameObject defUI;
    
    private void Update() 
    {
        if(!enemy.isInDefense)
        {
            enemy.RefilStats();
        }
        if(enemy.isInDefense)
        {
            defUI.SetActive(true);
        }
        else if(enemy.isInDefense)
        {
            defUI.SetActive(false);
        }
    }

    private void Start() 
    {
        enemy.StartStats();
    }
}

[System.Serializable]
public class BaseEnemyStat
{
    [Header("Stats de base")]
    [SerializeField] internal float baseHealth = 10;
    [SerializeField] internal float baseAttack = 5;
    [SerializeField] internal float baseDefense = 4;
    [SerializeField] internal float baseExp = 10;
    
}
    
[System.Serializable]
public class EnemyStat:BaseEnemyStat
{
    [Header("Autres Stats")]
    [SerializeField] internal EnemyManager changeEnemy;
    [SerializeField] internal Animator currentAnimator;
    [SerializeField] internal string playerName ="";
    [SerializeField] internal RuntimeAnimatorController animatorExplo;
    [SerializeField] internal RuntimeAnimatorController animatorFight;
    [SerializeField] internal float level=1;
    
    public float health, attack, defense, exp;
    public MonsterType type;
    public bool dead = false;
    public bool isInDefense;
    public bool hasCooldownDef;
    public int cooldownDef;
    public int ID;
    
    internal SoundManager soundManager;
    internal float maxHealth, maxAttack, maxDefense;

    [Header("Level Up Stats")]
    [SerializeField] internal float healthUp;
    [SerializeField] internal float attackUp;
    [SerializeField] internal float defenseUp;
    [SerializeField] internal float expUp;
    
    public bool isInFight; 
    
    public EnemyStat(string name)
    {
        this.playerName = name;
        this.maxHealth = this.baseHealth;
        this.maxAttack = this.baseAttack;
        this.maxDefense = this.baseDefense;
        this.exp = this.baseExp;
    }
    
    public void StartStats()
    {
        this.maxHealth = this.baseHealth + level * healthUp;
        this.maxAttack = this.baseAttack + level * attackUp;
        this.maxDefense = this.baseDefense + level * defenseUp;
        this.exp = this.baseExp + expUp * level ;
        Stats();
    }
    
    public void Level_up_stat(float up_level)
    {
        this.level = this.level+up_level;
        this.health = this.health + up_level*healthUp;
        this.attack = this.attack + up_level*attackUp;
        this.defense = this.defense + up_level*defenseUp;
        this.exp = this.exp + up_level*expUp;
    }

    public void TakeDmg(float dmg)
    {
        this.health = this.health - dmg;
        soundManager.SoundFightEnemyHurt();
    }

    internal void RefilStats()
    {
        this.defense = this.maxDefense;
    }
    
    private void Stats()
    {
        this.health = this.maxHealth;
        this.attack = this.maxAttack;
        this.defense = this.maxDefense;
    }
}
public enum MonsterType
{
    Vegetal,
    Mineral,
    Animal
}