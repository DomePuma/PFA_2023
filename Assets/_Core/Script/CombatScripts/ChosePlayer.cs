using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class ChosePlayer : MonoBehaviour
{
    [SerializeField] private GameObject _changePlayerGray;
    [SerializeField] private GameObject _changePlayerMaj;
    [SerializeField] private GameObject _changePlayerAsthym;
    [SerializeField] private GameObject _deathScreen;
    [SerializeField] private Button _deathRetryButton;
    [SerializeField] private GameObject[] _playerEmplacement;
    [SerializeField] private GameObject[] _playerEmplacementAtk;
    
    private GameObject _player;
    private GameObject _currentPlayerEmplacement;
    private GameObject _currentPlayerEmplacementAtk;
    private List<GameObject> _playerList;
    private int _currentPlayer;
    private TurnManager _turnManager;
    private TransfereData _transfereData;
    
    public Action ActionSendCharacterInfo;

    public GameObject Player
    {
        get => _player;
        set => _player = value;
    }
    
    public GameObject CurrentPlayerEmplacement
    {
        get => _currentPlayerEmplacement;
        set => _currentPlayerEmplacement = value;
    }
    
    public GameObject CurrentPlayerEmplacementAtk
    {
        get => _currentPlayerEmplacementAtk;
        set => _currentPlayerEmplacementAtk = value;
    }
    
    public List<GameObject> PlayerList
    {
        get => _playerList;
    }
    
    public int CurrentPlayer
    {
        get => _currentPlayer;
        set => _currentPlayer = value;
    }
    
    public void ChoseTank()
    {
        _changePlayerGray.SetActive(false);
        _changePlayerMaj.SetActive(false);
        _changePlayerAsthym.SetActive(false);
        
        Player = PlayerList[1];
        
        CurrentPlayerEmplacement = _playerEmplacement[1];
        CurrentPlayerEmplacementAtk = _playerEmplacementAtk[1];
        CurrentPlayer = 1;
        
        _turnManager.pA--;
        
        FindObjectOfType<UISelect>().SelectAtk();
        
        ActionSendCharacterInfo?.Invoke();

        if(_turnManager.pA <= 0)
        {
            _turnManager.PassTurn();
        }
    }

    public void ChoseHealer()
    {
        _changePlayerGray.SetActive(false);
        _changePlayerMaj.SetActive(false);
        _changePlayerAsthym.SetActive(false);
        
        Player = PlayerList[2];
        
        CurrentPlayerEmplacement = _playerEmplacement[2];
        CurrentPlayerEmplacementAtk = _playerEmplacementAtk[2];
        CurrentPlayer = 2;
        
        _turnManager.pA--;
        
        FindObjectOfType<UISelect>().SelectAtk();
        
        ActionSendCharacterInfo?.Invoke();

        if(_turnManager.pA <= 0)
        {
            _turnManager.PassTurn();
        }
    }

    public void ChoseFighter()
    {
        _changePlayerGray.SetActive(false);
        _changePlayerMaj.SetActive(false);
        _changePlayerAsthym.SetActive(false);
        
        Player = PlayerList[0];
        
        CurrentPlayerEmplacement = _playerEmplacement[0];
        CurrentPlayerEmplacementAtk = _playerEmplacementAtk[0];
        CurrentPlayer = 0;
        
        _turnManager.pA--;
        
        FindObjectOfType<UISelect>().SelectAtk();
        
        ActionSendCharacterInfo?.Invoke();

        if(_turnManager.pA <= 0)
        {
            _turnManager.PassTurn();
        }
    }

    public void PlayerDeath()
    {
        if(PlayerList[0].GetComponentInChildren<PlayerStats>().player.dead == true && PlayerList[1].GetComponentInChildren<PlayerStats>().player.dead == true && PlayerList[2].GetComponentInChildren<PlayerStats>().player.dead == true)
        {
            _deathScreen.SetActive(true);
            _deathRetryButton.Select();
        }
        else
        {
            Player.GetComponentInChildren<Animator>().SetBool("Death", true);
            CurrentPlayer += 1;
            
            if(CurrentPlayer > 2) 
            {
                CurrentPlayer = 0;
            }

            Player = PlayerList[CurrentPlayer];
            
            CurrentPlayerEmplacement = _playerEmplacement[CurrentPlayer];
            CurrentPlayerEmplacementAtk = _playerEmplacementAtk[CurrentPlayer];
            
            ActionSendCharacterInfo?.Invoke();

            if(PlayerList[CurrentPlayer].GetComponentInChildren<PlayerStats>().player.dead)
            {
                PlayerDeath();
            } 
        }
    }

    private void OnEnable() 
    {
        Player = PlayerList[0];
        
        CurrentPlayerEmplacement = _playerEmplacement[0];
        CurrentPlayerEmplacementAtk = _playerEmplacementAtk[0];
        
        switch(_transfereData.currentWeapon)
        {
            case 0:
                PlayerList[0].GetComponentInChildren<PlayerStats>().player.typeArmes = TypeArme.Ciseaux;
                break;
            case 1:
                PlayerList[0].GetComponentInChildren<PlayerStats>().player.typeArmes = TypeArme.Pioche;
                break;
            case 2:
                PlayerList[0].GetComponentInChildren<PlayerStats>().player.typeArmes = TypeArme.Marteau;
                break;
        }
    }

    private void Awake() 
    {
        _transfereData = FindObjectOfType<TransfereData>();
        _turnManager = FindObjectOfType<TurnManager>();
        
        PlayerList.Add(GameObject.FindGameObjectWithTag("Gray"));
        PlayerList.Add(GameObject.FindGameObjectWithTag("Asthym"));
        PlayerList.Add(GameObject.FindGameObjectWithTag("Maj"));
    }
}