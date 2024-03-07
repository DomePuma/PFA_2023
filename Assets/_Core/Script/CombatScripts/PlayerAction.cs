using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private GameObject _spellUI;
    [SerializeField] private GameObject[] _teamUIArray; 
    [SerializeField] private GameObject[] _spellArray;
    
    private ChosePlayer _chosePlayer;
    private EnemyManager _enemyManager;
    private AttackScript _attackScript;
    private UISelect _uISelect;
    private TurnManager _turnManager;

    public void Atk()
    {
        _chosePlayer.Player.GetComponentInChildren<Animator>().SetTrigger("Attack");
        _attackScript.Attack(_enemyManager.CurrentEnemy);
        
        _turnManager.pA = 0;
    }

    public void SpecialMove()
    {
        _spellUI.SetActive(true);
        
        switch(_chosePlayer.CurrentPlayer)
        {
            case 0:
            {
                _spellArray[0].SetActive(true);
                _uISelect.SelectSortGray();
                break;
            }
            case 1:
            {
                _spellArray[1].SetActive(true);
                _uISelect.SelectSortAsthym();
                break;
            }
            case 2:
            {
                _spellArray[2].SetActive(true);
                _uISelect.SelectSortMaj();
                break;
            }
        }
    }

    public void Epuipe()
    {
        switch(_chosePlayer.CurrentPlayer)
        {
            case 0:
            {
                _teamUIArray[0].SetActive(true);
                _uISelect.SelectEquipeGray();
                break;
            }
            case 1:
            {
                _teamUIArray[1].SetActive(true);
                _uISelect.SelectEquipeAsthym();
                break;
            }
            case 2:
            {
                _teamUIArray[2].SetActive(true);
                _uISelect.SelectEquipeMaj();
                break;
            }
        }
    }

    public void Fuite(string sceneName)
    {
        for(int i = 0; i < _chosePlayer.PlayerList.Count; i++)
        {
            _chosePlayer.PlayerList[i].gameObject.GetComponentInChildren<Animator>().SetTrigger("Fuite");
        }

        StartCoroutine(FuiteTimer(sceneName));
    }

    public void QuitUI()
    {
        switch(_chosePlayer.CurrentPlayer)
        {
            case 0:
            {
                _spellArray[0].SetActive(false);
                _spellArray[3].SetActive(false);
                break;
            }
            case 1:
            {
                _spellArray[1].SetActive(false);
                break;
            }
            case 2:
            {
                _spellArray[2].SetActive(false);
                break;
            }
        }

        _spellUI.SetActive(false);
        _uISelect.SelectAtk();
    }

    public void QuitEquipe()
    {
        for(int i = 0; i < _teamUIArray.Length; i++)
        {
            _teamUIArray[i].SetActive(false);
        }

        _uISelect.SelectAtk();
    }

    private IEnumerator FuiteTimer(string sceneName)
    {
        yield return new WaitForSecondsRealtime(3);
        FindObjectOfType<TransfereData>().Fuite(sceneName);
    }

    private void Awake() 
    {
        _chosePlayer = FindObjectOfType<ChosePlayer>();
        _enemyManager = FindObjectOfType<EnemyManager>();
        _attackScript = FindObjectOfType<AttackScript>();
        _turnManager = FindObjectOfType<TurnManager>();
        _uISelect = FindObjectOfType<UISelect>();
    }
}
