using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointActionUI : MonoBehaviour
{
    [SerializeField] private GameObject[] actionPointUI;
    private TurnManager turnManager;

    private void Update() 
    {
        if(turnManager.pA == 1)
        {
            actionPointUI[1].SetActive(false);
        }
        
        if(turnManager.pA == 2)
        {
            actionPointUI[1].SetActive(true);
        }
    }

    private void Awake() 
    {
        turnManager = FindObjectOfType<TurnManager>();      
    }
}
