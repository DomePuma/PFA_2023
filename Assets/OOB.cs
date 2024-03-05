using UnityEngine;
public class OOB : MonoBehaviour
{
    [SerializeField] private GameObject respawnPoint;
    
    private GameObject player;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.layer == 8)
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = respawnPoint.transform.position;
            player.GetComponent<CharacterController>().enabled = true;
        }
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
