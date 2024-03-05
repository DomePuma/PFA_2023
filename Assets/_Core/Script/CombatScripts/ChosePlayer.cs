using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;  

public class ChosePlayer : MonoBehaviour
{
    public GameObject dead;
    public GameObject player;
    public GameObject currentPlayerEmplacement;
    public GameObject currentPlayerEmplacementAtk;
    public List<GameObject> players;
    
    [System.NonSerialized] public int currentPlayer;
    
    [SerializeField] private GameObject panelGray;
    [SerializeField] private GameObject panelMaj;
    [SerializeField] private GameObject panelAsthym;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private Button deathRetryButton;
    [SerializeField] private GameObject[] playerEmplacement;
    [SerializeField] private GameObject[] playerEmplacementAtk;
    
    private TurnManager turnManager;
    private TransfereData transfereData;
    
    public void ChoseTank()
    {
        panelGray.SetActive(false);
        panelMaj.SetActive(false);
        panelAsthym.SetActive(false);
        player = players[1];
        currentPlayerEmplacement = playerEmplacement[1];
        currentPlayerEmplacementAtk = playerEmplacementAtk[1];
        currentPlayer = 1;
        turnManager.pA--;
        FindObjectOfType<UISelect>().SelectAtk();
        
        if(turnManager.pA <= 0)
        {
            turnManager.PassTurn();
        }
    }

    public void ChoseHealer()
    {
        panelGray.SetActive(false);
        panelMaj.SetActive(false);
        panelAsthym.SetActive(false);
        player = players[2];
        currentPlayerEmplacement = playerEmplacement[2];
        currentPlayerEmplacementAtk = playerEmplacementAtk[2];
        currentPlayer = 2;
        turnManager.pA--;
        FindObjectOfType<UISelect>().SelectAtk();
        
        if(turnManager.pA <= 0)
        {
            turnManager.PassTurn();
        }
    }

    public void ChoseFighter()
    {
        panelGray.SetActive(false);
        panelMaj.SetActive(false);
        panelAsthym.SetActive(false);
        player = players[0];
        currentPlayerEmplacement = playerEmplacement[0];
        currentPlayerEmplacementAtk = playerEmplacementAtk[0];
        currentPlayer = 0;
        turnManager.pA--;
        FindObjectOfType<UISelect>().SelectAtk();
        
        if(turnManager.pA <= 0)
        {
            turnManager.PassTurn();
        }
    }

    public void PlayerDeath()
    {
        if(players[0].GetComponentInChildren<PlayerStats>().player.dead == true && players[1].GetComponentInChildren<PlayerStats>().player.dead == true && players[2].GetComponentInChildren<PlayerStats>().player.dead == true)
        {
            player = dead;
            deathScreen.SetActive(true);
            deathRetryButton.Select();
        }
        else
        {
            player.GetComponentInChildren<Animator>().SetBool("Death", true);
            currentPlayer += 1;
            
            if(currentPlayer > 2) 
            {
                currentPlayer = 0;
            }

            player = players[currentPlayer];
            currentPlayerEmplacement = playerEmplacement[currentPlayer];
            currentPlayerEmplacementAtk = playerEmplacementAtk[currentPlayer];
            
            if(players[currentPlayer].GetComponentInChildren<PlayerStats>().player.dead)
            {
                PlayerDeath();
            }
            
        }
    }

    private void OnEnable() 
    {
        player = players[0];
        currentPlayerEmplacement = playerEmplacement[0];
        currentPlayerEmplacementAtk = playerEmplacementAtk[0];
        
        switch(transfereData.currentWeapon)
        {
            case 0:
                players[0].GetComponentInChildren<PlayerStats>().player.typeArmes = TypeArme.Ciseaux;
                break;
            case 1:
                players[0].GetComponentInChildren<PlayerStats>().player.typeArmes = TypeArme.Pioche;
                break;
            case 2:
                players[0].GetComponentInChildren<PlayerStats>().player.typeArmes = TypeArme.Marteau;
                break;
        }
    }

    private void Awake() 
    {
        transfereData = FindObjectOfType<TransfereData>();
        turnManager = FindObjectOfType<TurnManager>();
        players.Add(GameObject.FindGameObjectWithTag("Gray"));
        players.Add(GameObject.FindGameObjectWithTag("Asthym"));
        players.Add(GameObject.FindGameObjectWithTag("Maj"));
    }
}
