using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] GameObject gray;

    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        gray.GetComponent<CharacterController>().enabled = !gray.GetComponent<CharacterController>().enabled;
        gray.transform.position = GameObject.FindGameObjectWithTag("TransfereData").GetComponentInChildren<TransfereData>().playerExploPosition;
        gray.GetComponent<CharacterController>().enabled = !gray.GetComponent<CharacterController>().enabled;
    }
}
