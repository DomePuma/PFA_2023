using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabEnemyArray;
    [SerializeField] private GameObject[] _enemyLocationArray;
    [SerializeField] private GameObject[] _enemyAtkLocationArray;
    [SerializeField] private GameObject[] _enemyHealthPointBarArray;
    [SerializeField] private GameObject[] _defenseBuffUIArray;
    [SerializeField] private int _enemiesToGenerateCount;
    [SerializeField] private int _enemiesToGenerateMaxCount;
    [SerializeField] private GameObject _victoryScreen;
    
    private List<EnemyStats> _enemyList;
    private EnemyStats _currentEnemy;
    private Vector3 _currentEnemyPosition;
    private Vector3 _currentEnemyAtkPosition;
    private int _enemyRemainingCount;
    private int _xp;
    private int _enemiesCount;
    private TransfereData _transfereData;
    private List<GameObject> _enemiesGameObjectList;
    private int _enemyOrder;

    public List<EnemyStats> EnemyList
    {
        get => _enemyList;
    }
        
    public EnemyStats CurrentEnemy
    {
        get => _currentEnemy;
        set => _currentEnemy = value;
    }
    
    public Vector3 CurrentEnemyPosition
    {
        get => _currentEnemyPosition;
        set => _currentEnemyPosition = value;
    }

    public Vector3 CurrentEnemyAtkPosition
    {
        get => _currentEnemyAtkPosition;
        set => _currentEnemyAtkPosition = value;
    }

    public GameObject[] EmplacementEnemyArray
    {
        get => _enemyLocationArray;
        set => _enemyLocationArray = value;
    }
    
    public int EnemyRemainingCount
    {
        get => _enemyRemainingCount;
        set => _enemyRemainingCount = value;
    }

    public int XP
    {
        get => _xp;
        set => _xp = value;
    }

    public void SelectEnnemi()
    {
        _enemyOrder++;
        //if(enemyOrder > nbEnnemisRestants) enemyOrder = 0;
        if(_enemyOrder > 2) 
        {
            _enemyOrder = 0;
        }

        CurrentEnemy.selectLight.SetActive(false);
        CurrentEnemy = EnemyList[_enemyOrder];
        
        if(CurrentEnemy.enemy.dead == true) 
        {
            SelectEnnemi();
        }
        
        CurrentEnemyPosition = EmplacementEnemyArray[_enemyOrder].transform.position;
        CurrentEnemyAtkPosition = _enemyAtkLocationArray[_enemyOrder].transform.position;
        CurrentEnemy.selectLight.SetActive(true);
    }

    public void EnemyDeath()
    {
        EnemyRemainingCount--;
        CurrentEnemy.gameObject.GetComponentInChildren<Animator>().SetBool("Death", true);
        //currentEnnemi.gameObject.SetActive(false);
        if(EnemyRemainingCount == 0) EndFight();
        else SelectEnnemi();
    }

    public void EndFight()
    {
        _victoryScreen.SetActive(true);
        _transfereData.DestroyEnnemisList();
    }

    private int RandomNumberEnemy()
    {
        return Random.Range(_enemiesToGenerateCount,_enemiesToGenerateMaxCount);
    }

    private GameObject RandomTypeEnemy()
    {
        return Instantiate(_prefabEnemyArray[Random.Range(0,3)]);
    }

    private void generateEnnemis()
    {
        _enemiesToGenerateCount = _transfereData.ennemisAGenerer;
        _enemiesToGenerateMaxCount = _transfereData.enemiesMaxAGenerer; 
        _enemiesGameObjectList = _transfereData.enemiesToTransfere;
        _enemiesCount = RandomNumberEnemy();
        
        switch(_enemiesCount)
        {
            case 0:
                break;
            case 1:
                _enemiesGameObjectList.Add(RandomTypeEnemy());
                _enemyHealthPointBarArray[1].SetActive(true);
                break;
            case 2:
                _enemiesGameObjectList.Add(RandomTypeEnemy());
                _enemiesGameObjectList.Add(RandomTypeEnemy());
                _enemyHealthPointBarArray[1].SetActive(true);
                _enemyHealthPointBarArray[2].SetActive(true);
                break;
        }
        
        for (int j = 0; j < _enemiesGameObjectList.Count; j++)
        {
            EnemyList.Add(_enemiesGameObjectList[j].GetComponentInChildren<EnemyStats>());
            switch (EnemyList[j].enemy.type)
            {
                case MonsterType.Vegetal:
                    EnemyList[j].gameObject.transform.position = new Vector3(EmplacementEnemyArray[j].gameObject.transform.position.x, EmplacementEnemyArray[j].gameObject.transform.position.y, EmplacementEnemyArray[j].gameObject.transform.position.z);
                    if(SceneManager.GetActiveScene().name == "COMBAT FOREST")
                    {
                        EnemyList[j].gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
                    }
                    if(SceneManager.GetActiveScene().name == "COMBAT DONJON")
                    {
                        EnemyList[j].gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                    }
                    break;
                case MonsterType.Animal:
                    EnemyList[j].gameObject.transform.position = new Vector3(EmplacementEnemyArray[j].gameObject.transform.position.x, EmplacementEnemyArray[j].gameObject.transform.position.y + 1, EmplacementEnemyArray[j].gameObject.transform.position.z);
                    if(SceneManager.GetActiveScene().name == "COMBAT FOREST")
                    {
                        EnemyList[j].gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
                    }
                    if(SceneManager.GetActiveScene().name == "COMBAT DONJON")
                    {
                        EnemyList[j].gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                    }
                    break;
                case MonsterType.Mineral:
                    EnemyList[j].gameObject.transform.position = new Vector3(EmplacementEnemyArray[j].gameObject.transform.position.x, EmplacementEnemyArray[j].gameObject.transform.position.y, EmplacementEnemyArray[j].gameObject.transform.position.z);
                    if(SceneManager.GetActiveScene().name == "COMBAT FOREST")
                    {
                        EnemyList[j].gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
                    }
                    if(SceneManager.GetActiveScene().name == "COMBAT DONJON")
                    {
                        EnemyList[j].gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                    }
                    break;
            }
            //enemis[j].enemy.changeEnemy = this;
            EnemyList[j].enemy.soundManager = FindObjectOfType<SoundManager>();
            EnemyList[j].gameObject.GetComponent<Follower>().enabled = false;
            EnemyList[j].gameObject.GetComponentInChildren<Animator>().runtimeAnimatorController = EnemyList[j].enemy.animatorFight;
            EnemyList[j].defUI = _defenseBuffUIArray[j];
            EnemyList[j].enemy.changeEnemy = this;
        }
        
        EnemyRemainingCount = EnemyList.Count;
        CurrentEnemy = EnemyList[0];
        CurrentEnemyPosition = EmplacementEnemyArray[0].transform.position;
        CurrentEnemyAtkPosition = _enemyAtkLocationArray[0].transform.position;
        CurrentEnemy.selectLight.SetActive(true);
    }

    private void Awake() 
    {
        _transfereData = FindObjectOfType<TransfereData>();
        generateEnnemis();   
    }
}