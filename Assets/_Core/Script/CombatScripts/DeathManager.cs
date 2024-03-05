using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DeathManager : MonoBehaviour
{
    [SerializeField] private GameObject[] grayButtons;
    [SerializeField] private GameObject[] asthymButtons;
    [SerializeField] private GameObject[] majButtons;
    
    private List<GameObject> players;
    
    private void Start() 
    {
        players = FindObjectOfType<ChosePlayer>().players;
    }
    
    private void Update()
    {
        if(players[0].GetComponentInChildren<PlayerStats>().player.dead == true)
        {
            grayButtons[0].GetComponentInChildren<Button>().interactable = false;
            grayButtons[1].GetComponentInChildren<Button>().interactable = false;
        }
        
        if(players[1].GetComponentInChildren<PlayerStats>().player.dead == true)
        {
            asthymButtons[0].GetComponentInChildren<Button>().interactable = false;
            asthymButtons[1].GetComponentInChildren<Button>().interactable = false;
        }
        
        if(players[2].GetComponentInChildren<PlayerStats>().player.dead == true)
        {
            majButtons[0].GetComponentInChildren<Button>().interactable = false;
            majButtons[1].GetComponentInChildren<Button>().interactable = false;
        }
    }
}
