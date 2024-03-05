using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private int nbSwitchNeed;
    [SerializeField] private GameObject[] doorParts;
    
    private TransfereData transfereData;

    void Awake() 
    {
        transfereData = FindObjectOfType<TransfereData>();
    }
    
    void Update()
    {
        if(transfereData.nbSwitchActive == nbSwitchNeed)
        {
            for(int i = 0; i< doorParts.Length; i++)
            {
                doorParts[i].GetComponent<Animator>().SetTrigger("OpenDoor");
            }
        }
    }
}
