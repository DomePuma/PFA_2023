using UnityEngine;

public class Platforms : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if(hit.gameObject.layer == 9)
        {
            this.gameObject.transform.SetParent(hit.gameObject.transform);
            Debug.Log("PlayerPlatform");
        }
        else if(hit.gameObject.layer != 9)
        {
            this.gameObject.transform.parent = null;
        }
    }
}
