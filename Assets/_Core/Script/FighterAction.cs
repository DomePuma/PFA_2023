using UnityEngine;

public class FighterAction : MonoBehaviour
{
    [SerializeField] public EnemyStats enemy;
    [SerializeField] private AttackScript action;
    private GameObject player;

    [SerializeField] private EnemyManager enemyManager;
    
    [SerializeField] private Animator animator;
    [SerializeField] private Sprite faceIcon;
    [SerializeField] private GameObject uiSorts;
    private void Start() 
    {
        enemy = enemyManager.currentEnnemi;
    }
    public void SelectAttack(string btn) 
    {
        enemy = enemyManager.currentEnnemi;
        // GameObject victim = player;
        // if(tag == "Player")
        // {
        //     victim = enemy;
        // }
        switch(btn)
        {
            case "Attaque":
                Debug.Log("Attaque");
                action.Attack(enemy);
                animator.SetTrigger("Attaque");
                break;
            case "SpecialMove":
                Debug.Log("Attaques Spéciales");
                uiSorts.SetActive(true);
                animator.SetTrigger("Garde");
                break;
            case "Equipe":
                Debug.Log("Equipe");
                break;
            default :
                Debug.Log("Fuite");
                action.LevelUP(1);
                //animator.SetTrigger("Fuite");
                break;
        }
    }

}
