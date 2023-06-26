using UnityEngine;
public class AtkExplo : MonoBehaviour
{
    [SerializeField] string fightSceneName;
    bool hasEnemyHit;
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Weapon" && hasEnemyHit == false)
        {
            hasEnemyHit = true;
            TransfereData transfereData = GameObject.FindGameObjectWithTag("TransfereData").GetComponent<TransfereData>();
            transfereData.enemiesToTransfere.Add(this.gameObject);
            transfereData.ChangeSceneToFight("COMBAT FOREST");
        }
    }
}