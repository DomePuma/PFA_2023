using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Image healthBar;

    private void Update() 
    {
        healthBar.fillAmount = (playerStats.player.health/playerStats.player.maxHealth);
    }
}
