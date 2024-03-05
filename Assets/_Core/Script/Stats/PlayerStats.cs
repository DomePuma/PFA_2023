using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public PlayerStat player = new PlayerStat("", 1);

    public void LevelUP()
    {
        player.Level_up_stat(1);
    }

    private void Update() 
    {
        if(player.health >= player.maxHealth)
        {
            player.health = player.maxHealth;
        }
        if(player.defense >= player.maxDefense)
        {
            player.defense = player.maxDefense;
        }
        if(player.attack >= player.maxAttack)
        {
            player.attack = player.maxAttack;
        }
    }
    
    private void Start() 
    {
        player.StartStats(FindObjectOfType<TransfereData>().lvPlayer);
    }

    private void Awake() 
    {
        if(player.playerName == null||player.playerName == "")
        {
            Debug.Break();
        }
        if(this.gameObject.tag != "Gray")
        {
            player.typeArmes = TypeArme.Autre;
        }
        else
        {
            player.typeArmes = TypeArme.Ciseaux;
        }
        
        player.soundManager = FindObjectOfType<SoundManager>();
    }
}
[System.Serializable]
public class Basestat
{
    [Header("Stats de base")]
    [SerializeField] internal float baseHealth = 10;
    [SerializeField] internal float baseAttack = 5;
    [SerializeField] internal float baseDefense = 4;
}
    
[System.Serializable]
public class PlayerStat:Basestat
{
    [Header("Autres Stats")]
    [SerializeField] internal string playerName ="";
    [SerializeField] internal float level;
    
    public TypeArme typeArmes;
    public Sprite icon;
    public float health, attack, defense;
    public bool isInvincible;
    public bool dead = false;
    
    internal float maxHealth, maxAttack, maxDefense;
    internal SoundManager soundManager;

    [Header("Level Up Stats")]
    [SerializeField] internal float healthUp;
    [SerializeField] internal float attackUp;
    [SerializeField] internal float defenseUp;

    public PlayerStat(string name, int playerLv)
    {
        this.level = playerLv;
        this.playerName = name;
        this.maxHealth = this.baseHealth * playerLv;
        this.maxAttack = this.baseAttack * playerLv;
        this.maxDefense = this.baseDefense * playerLv;
    }
    public void Level_up_stat(float up_level)
    {
        this.level = this.level+up_level;
        this.maxHealth = this.maxHealth + up_level*healthUp;
        this.maxAttack = this.maxAttack + up_level*attackUp;
        this.maxDefense = this.maxDefense + up_level*defenseUp;
        
    }
    public void StartStats(int lv)
    {
        this.level = lv;
        this.maxHealth = this.maxHealth + lv*healthUp;
        this.maxAttack = this.maxAttack + lv*attackUp;
        this.maxDefense = this.maxDefense + lv*defenseUp;
        RefilStats();
    }
    private void RefilStats()
    {
        this.health = this.maxHealth;
        this.attack = this.maxAttack;
        this.defense = this.maxDefense;
    }
    public void TakeDmg(float dmg)
    {
        if(!isInvincible)
        {
            this.health = this.health - dmg;
            soundManager.SoundFightEnemyHurt();
        }
        if(isInvincible)
        {
            this.health = this.health - (dmg*.2f);
        }
    }
}
public enum TypeArme
{
    Marteau,
    Pioche,
    Ciseaux,
    Autre
}
