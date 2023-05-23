using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionEnnemis : MonoBehaviour
{
    [SerializeField] TransfereData transfereData; 
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.gameObject.tag == "Vegetal")
        {
            Debug.Log(hit);
            transfereData.enemiesToTransfere.Add(hit.gameObject);
            transfereData.ChangeScene();
        }
    }
}