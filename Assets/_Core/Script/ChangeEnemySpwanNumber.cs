using UnityEngine;

public class ChangeEnemySpwanNumber : MonoBehaviour
{
    [SerializeField] private int ennemisAGenerer;
    [SerializeField] private int enemiesMaxAGenerer;
    private TransfereData transfereData;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Weapon")
        {
            transfereData.enemiesMaxAGenerer = enemiesMaxAGenerer;
            transfereData.ennemisAGenerer = ennemisAGenerer;
        }
    }

    private void Awake() 
    {
        transfereData = FindObjectOfType<TransfereData>();
    }
}
