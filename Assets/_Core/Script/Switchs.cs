using UnityEngine;

public class Switchs : MonoBehaviour
{
    bool hasBeenPress;
    private void OnCollisionEnter(Collision other) 
    {
        Debug.Log("Button");
        
        if(other.gameObject.tag == "Weapon" && 
        other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>()._currentWeapon == 2 &&
        other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isAttacking &&
        !hasBeenPress)
        {
            this.GetComponentInChildren<Animator>().SetTrigger("PushButton");
            hasBeenPress = true;
            FindObjectOfType<TransfereData>().Switchs();
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
