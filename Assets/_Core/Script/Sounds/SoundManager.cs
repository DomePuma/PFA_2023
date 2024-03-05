using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [Header("Weapons")]
    [SerializeField] private AudioClip fightSword;
    [SerializeField] private AudioClip fightPickaxe;
    [SerializeField] private AudioClip fightHammer;
    [SerializeField] private AudioClip fightMajAttack;

    [Header("Buffs")]
    [SerializeField] private AudioClip fightAtkBuff;
    [SerializeField] private AudioClip fightDefPosition;
    
    [Header("Spells")]
    [SerializeField] private AudioClip fightHeal;
    [SerializeField] private AudioClip fightSwitch;

    [Header("Other")]
    [SerializeField] private AudioClip fightHurt;
    [SerializeField] private AudioSource audioSource;

    private EnemyStats[] ennemis;
    private PlayerStats[] players;
    
    public void SoundFightSword()
    {
        audioSource.clip = fightSword;
        audioSource.Play();
    }
    public void SoundFightPickaxe()
    {
        audioSource.clip = fightPickaxe;
        audioSource.Play();
    }
    public void SoundFightHammer()
    {
        audioSource.clip = fightHammer;
        audioSource.Play();
    }
    public void SoundFightAllyHurt()
    {
        audioSource.clip = fightHurt;
        audioSource.Play();
    }
    public void SoundFightEnemyHurt()
    {
        audioSource.clip = fightHurt;
        audioSource.Play();
    }
    public void SoundFightAtkBuff()
    {
        audioSource.clip = fightAtkBuff;
        audioSource.Play();
    }
    public void SoundFightDefPosition()
    {
        audioSource.clip = fightDefPosition;
        audioSource.Play();
    }
    public void SoundFightHeal()
    {
        audioSource.clip = fightHeal;
        audioSource.Play();
    }
    public void SoundFightMajAttack()
    {
        audioSource.clip = fightMajAttack;
        audioSource.Play();
    }
    public void SoundFightSwitch()
    {
        audioSource.clip = fightSwitch;
        audioSource.Play();
    }

    private void enemyConfigSound()
    {
        ennemis = FindObjectsOfType<EnemyStats>();
        
        for(int i = 0; i < ennemis.Length; i++)
        {
            ennemis[i].enemy.soundManager = this;
        }
    }

    private void playerConfigSound()
    {
        players = FindObjectsOfType<PlayerStats>();
        
        for(int i = 0; i < players.Length; i++)
        {
            players[i].player.soundManager = this;
        }

    }

    private void Start()
    {
        enemyConfigSound();
        playerConfigSound();
    }
}
