using UnityEngine;

public class EnemyListStarter : MonoBehaviour
{
    void Start()
    {
        TransfereData transfereData = FindObjectOfType<TransfereData>();
        transfereData.enemyIsInDestroyList = false;
        //transfereData.GenerateEnnemisList();
        transfereData.EnemyToDestroy();
    }
}
