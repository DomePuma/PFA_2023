using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{
    [SerializeField] private int nbEnemy;
    [SerializeField] private Image healthBar;
    private EnemyStats enemyStats;
    
    private void Update() 
    {
        healthBar.fillAmount = (enemyStats.enemy.health/enemyStats.enemy.maxHealth);
    }

    private void Start() 
    {
        enemyStats = FindObjectOfType<EnemyManager>().EnemyList[nbEnemy];
    }
}
