using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DeathManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _grayButtons;
    [SerializeField] private GameObject[] _asthymButtons;
    [SerializeField] private GameObject[] _majButtons;
    
    private List<GameObject> _players;
    
    private void Start() 
    {
        _players = FindObjectOfType<ChosePlayer>().PlayerList;
    }
    
    private void Update()
    {
        if(_players[0].GetComponentInChildren<PlayerStats>().player.dead == true)
        {
            _grayButtons[0].GetComponentInChildren<Button>().interactable = false;
            _grayButtons[1].GetComponentInChildren<Button>().interactable = false;
        }
        
        if(_players[1].GetComponentInChildren<PlayerStats>().player.dead == true)
        {
            _asthymButtons[0].GetComponentInChildren<Button>().interactable = false;
            _asthymButtons[1].GetComponentInChildren<Button>().interactable = false;
        }
        
        if(_players[2].GetComponentInChildren<PlayerStats>().player.dead == true)
        {
            _majButtons[0].GetComponentInChildren<Button>().interactable = false;
            _majButtons[1].GetComponentInChildren<Button>().interactable = false;
        }
    }
}
