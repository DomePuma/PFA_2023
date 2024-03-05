using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectionEnnemis : MonoBehaviour
{
    [SerializeField] string sceneName;
    
    bool hasEnemyHit;
    
    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if(hit.gameObject.tag == "Enemy")
        {
            if(hasEnemyHit == false)
            {
                hasEnemyHit = true;
                Debug.Log("EnemyHit");
                TransfereData transfereData = GameObject.FindGameObjectWithTag("TransfereData").GetComponent<TransfereData>();
                transfereData.enemiesToTransfere.Add(hit.gameObject);
                transfereData.enemyStartFight = true;
                transfereData.ChangeSceneToFight(sceneName);
            }
        }
    }
}