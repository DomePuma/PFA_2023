using UnityEngine;
public class AtkExplo : MonoBehaviour
{
    [SerializeField] string fightSceneName;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Weapon")
        {
            TransfereData transfereData = GameObject.FindGameObjectWithTag("TransfereData").GetComponent<TransfereData>();
            transfereData.enemiesToTransfere.Add(this.gameObject);
            transfereData.ChangeSceneToFight("COMBAT FOREST");
        }
    }
}