using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransfereData : MonoBehaviour
{
    public bool enemyIsInDestroyList;
    public int nbSwitchActive;
    public List<GameObject> enemiesToTransfere;
    public Vector3 playerExploPosition;
    public bool enemyStartFight;
    public List<int> enemyIDs;
    public int currentWeapon;
    public int storedXP;
    public int lvPlayer;
    public int ennemisAGenerer;
    public int enemiesMaxAGenerer;

    private GameObject[] enemyList;
    private List<GameObject> enemyListToDestroy;
    
    public void ChangeSceneToFight(string sceneName)
    {
        playerExploPosition = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(enemiesToTransfere[0]);
        currentWeapon = FindObjectOfType<StarterAssets.ThirdPersonController>()._currentWeapon;
        SceneManager.LoadScene(sceneName);
    }
    public void ChangeSceneToExplo(string sceneName)
    {
        storedXP += (int)FindObjectOfType<EnemyManager>().xp;
        DontDestroyOnLoad(this.gameObject);
        Destroy(enemiesToTransfere[0]);
        SceneManager.LoadScene(sceneName);
        enemiesToTransfere.Clear();
        
    }
    public void ChangeScene(string sceneName)
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene(sceneName);
        enemyIDs.Clear();
    }
    public void Fuite(string sceneName)
    {
        DontDestroyOnLoad(this.gameObject);
        Destroy(enemiesToTransfere[0]);
        SceneManager.LoadScene(sceneName);
        enemiesToTransfere.Clear();
    }
    public void DestroyEnnemisList()
    {
        if(enemyIsInDestroyList == false)
        {
            Debug.Log("EnemyDestroyList");
            enemyIsInDestroyList = true;
            enemyIDs.Add(enemiesToTransfere[0].GetComponent<EnemyStats>().enemy.ID);    
        }      
    }
    public void EnemyToDestroy()
    {
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < enemyList.Length; i++)
        {
            for(int j = 0; j < enemyIDs.Count; j++)
            {
                if(enemyList[i].GetComponentInChildren<EnemyStats>().enemy.ID == enemyIDs[j])
                {
                    Destroy(enemyList[i].gameObject);
                }
            }
        }       
    }
    public void Switchs()
    {
        nbSwitchActive++;
    }
    private void Update() {
        
        switch(storedXP)
        {
            case >= 2000:
                lvPlayer = 10;
                break;
            case >= 1000:
                lvPlayer = 9;
                break;
            case >= 750:
                lvPlayer = 8;
                break;
            case >= 450:
                lvPlayer = 7;
                break;
            case >= 300:
                lvPlayer = 6;
                break;
            case >= 200:
                lvPlayer = 5;
                break;
            case >= 100:
                lvPlayer = 4;
                break;
            case >= 50:
                lvPlayer = 3;
                break;
            case >= 10:
                lvPlayer = 2;
                break;            
        }
    }
}