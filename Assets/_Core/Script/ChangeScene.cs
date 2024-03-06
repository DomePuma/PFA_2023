using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] string sceneName;
    
    private void OnTriggerEnter(Collider other) 
    {
        FindObjectOfType<TransfereData>().ChangeScene(sceneName);
        FindObjectOfType<TransfereData>().playerExploPosition = new Vector3(-31.01f, 3.658f, -1.56f);
    }
}
