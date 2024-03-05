using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public List<EnemyStats> enemis;
    public EnemyStats currentEnnemi;
    public Vector3 currentEnnemiPosition;
    public Vector3 currentEnnemiAtkPosition;
    public GameObject[] emplacementEnnemis;
    public float nbEnnemisRestants;
    public float xp;
    
    [SerializeField] private GameObject[] prefabEnnemis;
    [SerializeField] private GameObject[] emplacementAtkEnnemis;
    [SerializeField] private GameObject[] hpBarEnemy;
    [SerializeField] private GameObject[] defBuffUI;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private int ennemisAGenerer;
    [SerializeField] private int ennemisMaxAGenerer;

    private int nbEnemies;
    private TransfereData transfereData;
    private List<GameObject> enemisObj;
    private int enemyOrder;

    public void SelectEnnemi()
    {
        enemyOrder++;
        //if(enemyOrder > nbEnnemisRestants) enemyOrder = 0;
        if(enemyOrder > 2) 
        {
            enemyOrder = 0;
        }

        currentEnnemi.selectLight.SetActive(false);
        currentEnnemi = enemis[enemyOrder];
        
        if(currentEnnemi.enemy.dead == true) 
        {
            SelectEnnemi();
        }
        
        currentEnnemiPosition = emplacementEnnemis[enemyOrder].transform.position;
        currentEnnemiAtkPosition = emplacementAtkEnnemis[enemyOrder].transform.position;
        currentEnnemi.selectLight.SetActive(true);
    }

    public void EnemyDeath()
    {
        nbEnnemisRestants--;
        currentEnnemi.gameObject.GetComponentInChildren<Animator>().SetBool("Death", true);
        //currentEnnemi.gameObject.SetActive(false);
        if(nbEnnemisRestants == 0) EndFight();
        else SelectEnnemi();
    }

    public void EndFight()
    {
        victoryScreen.SetActive(true);
        transfereData.DestroyEnnemisList();
    }

    private int RandomNumberEnemy()
    {
        return Random.Range(ennemisAGenerer,ennemisMaxAGenerer);
    }

    private GameObject RandomTypeEnemy()
    {
        return Instantiate(prefabEnnemis[Random.Range(0,3)]);
    }

    private void generateEnnemis()
    {
        ennemisAGenerer = transfereData.ennemisAGenerer;
        ennemisMaxAGenerer = transfereData.enemiesMaxAGenerer; 
        enemisObj = transfereData.enemiesToTransfere;
        nbEnemies = RandomNumberEnemy();
        
        switch(nbEnemies)
        {
            case 0:
                break;
            case 1:
                enemisObj.Add(RandomTypeEnemy());
                hpBarEnemy[1].SetActive(true);
                break;
            case 2:
                enemisObj.Add(RandomTypeEnemy());
                enemisObj.Add(RandomTypeEnemy());
                hpBarEnemy[1].SetActive(true);
                hpBarEnemy[2].SetActive(true);
                break;
        }
        
        for (int j = 0; j < enemisObj.Count; j++)
        {
            enemis.Add(enemisObj[j].GetComponentInChildren<EnemyStats>());
            switch (enemis[j].enemy.type)
            {
                case MonsterType.Vegetal:
                    enemis[j].gameObject.transform.position = new Vector3(emplacementEnnemis[j].gameObject.transform.position.x, emplacementEnnemis[j].gameObject.transform.position.y, emplacementEnnemis[j].gameObject.transform.position.z);
                    if(SceneManager.GetActiveScene().name == "COMBAT FOREST")
                    {
                        enemis[j].gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
                    }
                    if(SceneManager.GetActiveScene().name == "COMBAT DONJON")
                    {
                        enemis[j].gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                    }
                    break;
                case MonsterType.Animal:
                    enemis[j].gameObject.transform.position = new Vector3(emplacementEnnemis[j].gameObject.transform.position.x, emplacementEnnemis[j].gameObject.transform.position.y + 1, emplacementEnnemis[j].gameObject.transform.position.z);
                    if(SceneManager.GetActiveScene().name == "COMBAT FOREST")
                    {
                        enemis[j].gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
                    }
                    if(SceneManager.GetActiveScene().name == "COMBAT DONJON")
                    {
                        enemis[j].gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                    }
                    break;
                case MonsterType.Mineral:
                    enemis[j].gameObject.transform.position = new Vector3(emplacementEnnemis[j].gameObject.transform.position.x, emplacementEnnemis[j].gameObject.transform.position.y, emplacementEnnemis[j].gameObject.transform.position.z);
                    if(SceneManager.GetActiveScene().name == "COMBAT FOREST")
                    {
                        enemis[j].gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
                    }
                    if(SceneManager.GetActiveScene().name == "COMBAT DONJON")
                    {
                        enemis[j].gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                    }
                    break;
            }
            //enemis[j].enemy.changeEnemy = this;
            enemis[j].enemy.soundManager = FindObjectOfType<SoundManager>();
            enemis[j].gameObject.GetComponent<Follower>().enabled = false;
            enemis[j].gameObject.GetComponentInChildren<Animator>().runtimeAnimatorController = enemis[j].enemy.animatorFight;
            enemis[j].defUI = defBuffUI[j];
            enemis[j].enemy.changeEnemy = this;
        }
        
        nbEnnemisRestants = enemis.Count;
        currentEnnemi = enemis[0];
        currentEnnemiPosition = emplacementEnnemis[0].transform.position;
        currentEnnemiAtkPosition = emplacementAtkEnnemis[0].transform.position;
        currentEnnemi.selectLight.SetActive(true);
    }

    private void Awake() 
    {
        transfereData = FindObjectOfType<TransfereData>();
        generateEnnemis();   
    }
}