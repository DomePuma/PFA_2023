using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] private ChosePlayer _chosePlayer;
    [SerializeField] private Image _currentIcon;
    [SerializeField] private TMP_Text _currentName;

    private void ChangeCharacterInfo()
    {
        _currentIcon.sprite = _chosePlayer.Player.GetComponentInChildren<PlayerStats>().player.icon;
        _currentName.text = _chosePlayer.Player.GetComponentInChildren<PlayerStats>().player.playerName;
    }

    private void OnDisable()
    {
        _chosePlayer.ActionSendCharacterInfo -= ChangeCharacterInfo;
    }

    private void OnEnable()
    {
        _chosePlayer.ActionSendCharacterInfo += ChangeCharacterInfo;
    }
}
