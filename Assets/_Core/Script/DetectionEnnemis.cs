using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionEnnemis : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.gameObject.tag == "Enemy")
        {
            TransfereData transfereData = GameObject.FindGameObjectWithTag("TransfereData").GetComponent<TransfereData>();
            Debug.Log(hit);
            transfereData.enemiesToTransfere.Add(hit.gameObject);
            transfereData.enemyStartFight = true;
            //transfereData.enemyIDs.Add(hit.gameObject.GetComponentInChildren<EnemyStats>().enemy.ID);
            transfereData.ChangeSceneToFight();
        }
    }
}