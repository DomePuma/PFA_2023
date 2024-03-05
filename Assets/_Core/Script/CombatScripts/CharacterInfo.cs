using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] private ChosePlayer player;
    [SerializeField] private Image currentIcon;
    [SerializeField] private TMP_Text currentName;
    [SerializeField] private Sprite deadPlaceHolder;

    private void Update() 
    {
        if(player.player == player.dead)
        {
           currentIcon.sprite = deadPlaceHolder;
           currentName.text = "Dead";
        }
        else
        {
            currentIcon.sprite = player.player.GetComponentInChildren<PlayerStats>().player.icon;
            currentName.text = player.player.GetComponentInChildren<PlayerStats>().player.playerName;
        }    
    }
}
