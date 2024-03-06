using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private GameObject uiSorts;
    [SerializeField] private GameObject[] uiEquipe; 
    [SerializeField] private GameObject[] spells;
    
    private ChosePlayer chosePlayer;
    private EnemyManager enemyManager;
    private AttackScript attackScript;
    private UISelect uISelect;
    private TurnManager turnManager;

    public void Atk()
    {
        chosePlayer.Player.GetComponentInChildren<Animator>().SetTrigger("Attack");
        attackScript.Attack(enemyManager.currentEnnemi);
        turnManager.pA = 0;
    }

    public void SpecialMove()
    {
        Debug.Log("Attaques Spéciales");
        uiSorts.SetActive(true);
        
        switch(chosePlayer.CurrentPlayer)
        {
            case 0:
            {
                spells[0].SetActive(true);
                uISelect.SelectSortGray();
                break;
            }
            case 1:
            {
                spells[1].SetActive(true);
                uISelect.SelectSortAsthym();
                break;
            }
            case 2:
            {
                spells[2].SetActive(true);
                uISelect.SelectSortMaj();
                break;
            }
        }
    }

    public void Epuipe()
    {
        Debug.Log("Equipe");
        switch(chosePlayer.CurrentPlayer)
        {
            case 0:
            {
                Debug.Log("ChangerGray");
                uiEquipe[0].SetActive(true);
                uISelect.SelectEquipeGray();
                break;
            }
            case 1:
            {
                Debug.Log("ChangerAsthym");
                uiEquipe[1].SetActive(true);
                uISelect.SelectEquipeAsthym();
                break;
            }
            case 2:
            {
                Debug.Log("ChangerMaj");
                uiEquipe[2].SetActive(true);
                uISelect.SelectEquipeMaj();
                break;
            }
        }
    }

    public void Fuite(string sceneName)
    {
        for(int i = 0; i < chosePlayer.PlayerList.Count; i++)
        {
            chosePlayer.PlayerList[i].gameObject.GetComponentInChildren<Animator>().SetTrigger("Fuite");
        }

        StartCoroutine(FuiteTimer(sceneName));
        
    }

    public void QuitUI()
    {
        switch(chosePlayer.CurrentPlayer)
        {
            case 0:
            {
                spells[0].SetActive(false);
                spells[3].SetActive(false);
                break;
            }
            case 1:
            {
                spells[1].SetActive(false);
                break;
            }
            case 2:
            {
                spells[2].SetActive(false);
                break;
            }
        }

        uiSorts.SetActive(false);
        uISelect.SelectAtk();
    }

    public void QuitEquipe()
    {
        for(int i = 0; i < uiEquipe.Length; i++)
        {
            uiEquipe[i].SetActive(false);
        }

        uISelect.SelectAtk();
    }

    private IEnumerator FuiteTimer(string sceneName)
    {
        yield return new WaitForSecondsRealtime(3);
        FindObjectOfType<TransfereData>().Fuite(sceneName);
    }

    private void Awake() 
    {
        chosePlayer = FindObjectOfType<ChosePlayer>();
        enemyManager = FindObjectOfType<EnemyManager>();
        attackScript = FindObjectOfType<AttackScript>();
        turnManager = FindObjectOfType<TurnManager>();
        uISelect = FindObjectOfType<UISelect>();
    }
}
