using UnityEngine;
using System.Collections;

public class StartFight : MonoBehaviour
{
    [SerializeField] private PlayerStats gray;
    [SerializeField] private GameObject UI;

    private TurnManager turnManager;
    private TransfereData transfereData;
    
    private IEnumerator FirstTurn()
    {
        yield return new WaitForSecondsRealtime(1);
        
        if(GameObject.FindGameObjectWithTag("TransfereData").GetComponent<TransfereData>().enemyStartFight == true)
        {
            turnManager.PassTurn();
        }
        else
        {
            turnManager.pA = 2;
            UI.SetActive(true);
        }
    }

    private void Start()
    {
        switch(transfereData.currentWeapon)
        {
            case 0 :
                Debug.Log("Ciseau");
                gray.player.typeArmes = TypeArme.Ciseaux;
                gray.gameObject.GetComponentInChildren<Animator>().SetTrigger("StartCiseau");
                break;
            case 1 :
                Debug.Log("Pioche");
                gray.player.typeArmes = TypeArme.Pioche;
                gray.gameObject.GetComponentInChildren<Animator>().SetTrigger("StartPioche");
                break;
            case 2 :
                Debug.Log("Marteau");
                gray.player.typeArmes = TypeArme.Marteau;
                gray.gameObject.GetComponentInChildren<Animator>().SetTrigger("StartMarteau");
                break;
        }
        
        StartCoroutine(FirstTurn());
    }

    private void Awake() 
    {
        transfereData = FindObjectOfType<TransfereData>();
        turnManager = FindObjectOfType<TurnManager>();
    }
}
