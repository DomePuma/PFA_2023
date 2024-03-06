using UnityEngine;

public class EcranTitre : MonoBehaviour
{
    [SerializeField] private string sceneName;
    
    private void Start()
    {
        FindObjectOfType<TransfereData>().ChangeScene(sceneName);
    }
}
