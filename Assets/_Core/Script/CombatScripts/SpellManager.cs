using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public bool isInGuard;
    
    [SerializeField] private GameObject panneauArmes;
    [SerializeField] private GameObject healParticle;
    [SerializeField] private GameObject atkParticle;
    [SerializeField] private GameObject defParticle;
    [SerializeField] private float percentHealthHealed;
    
    private PlayerAction playerAction;
    private SoundManager soundManager;
    private PlayerStats[] player;
    private TurnManager turnManager;
    private ChosePlayer chosePlayer;

    public void ChangementArmes()
    {
        panneauArmes.SetActive(true);
    }

    public void MiseEnGarde()
    {
        if(turnManager.pA == 2)
        {
            Debug.Log("Mise En Guard");
            playerAction.QuitUI();
            chosePlayer.Player.GetComponentInChildren<Animator>().SetTrigger("Garde");
            isInGuard = true;
            turnManager.pA -= 2;
        }
        else
        {
            Debug.Log("Pas assez de PA");
        }
    }

    public void BouclierHumain()
    {
        Debug.Log("Bouclier Humain");
        playerAction.QuitUI();
        turnManager.hasDefBuff = true;
        turnManager.defBuffCooldown = 3;
        turnManager.pA -= 1;
        chosePlayer.Player.GetComponentInChildren<Animator>().SetTrigger("BouclierHumain");
        defParticle.SetActive(true);
    }

    public void PositionDefense()
    {
        if(turnManager.pA == 2)
        {
            Debug.Log("Position de Defense");
            chosePlayer.Player.GetComponentInChildren<PlayerStats>().player.isInvincible = true;
            playerAction.QuitUI();
            turnManager.pA -= 2;
            chosePlayer.Player.GetComponentInChildren<Animator>().SetTrigger("PositionDeDefense");
            soundManager.SoundFightDefPosition();
        }
        else
        {
            Debug.Log("Pas assez de PA");
        }
        
    }

    public void Soins()
    {
        for(int i = 0; i < player.Length; i++)
        {
            player[i].player.health += player[i].player.maxHealth * (percentHealthHealed/100);
        }

        playerAction.QuitUI();
        turnManager.pA -= 1;
        chosePlayer.Player.GetComponentInChildren<Animator>().SetTrigger("Heal");
        soundManager.SoundFightHeal();
        healParticle.SetActive(true);
    }

    public void Amplification()
    {
        if(turnManager.pA == 2)
        {
            Debug.Log("Amplification");
            turnManager.hasAtkBuff = true;
            turnManager.atkBuffCooldown = 3;
            playerAction.QuitUI();
            turnManager.pA -= 2;
            chosePlayer.Player.GetComponentInChildren<Animator>().SetTrigger("Amplifie");
            soundManager.SoundFightAtkBuff();
            atkParticle.SetActive(true);
        }
        else
        {
            Debug.Log("Pas assez de PA");
        }
    }

    private void Start() 
    {
        player = FindObjectsOfType<PlayerStats>();
        soundManager = FindObjectOfType<SoundManager>();
        turnManager = FindObjectOfType<TurnManager>();
        playerAction = FindObjectOfType<PlayerAction>();
        chosePlayer = FindObjectOfType<ChosePlayer>();
    }
}