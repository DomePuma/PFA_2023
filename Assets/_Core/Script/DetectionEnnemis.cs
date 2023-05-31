using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionEnnemis : MonoBehaviour
{
    [SerializeField] TransfereDataToFight transfereData; 
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.gameObject.tag == "Enemy")
        {
            Debug.Log(hit);
            transfereData.enemiesToTransfere.Add(hit.gameObject);
            transfereData.ChangeScene();
        }
    }
}