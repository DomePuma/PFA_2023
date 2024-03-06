using UnityEngine;

public class BreakableRocks : MonoBehaviour
{
    private bool hasBeenBreak;
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Weapon" && 
        other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>()._currentWeapon == 1 &&
        other.gameObject.GetComponentInParent<StarterAssets.ThirdPersonController>().isAttacking &&
        !hasBeenBreak)
        {
            Rigidbody[] rocks = GetComponentsInChildren<Rigidbody>();
            BoxCollider[] boxCollider = GetComponents<BoxCollider>();
            
            for(int i = 0; i < rocks.Length; i++)
            {
                rocks[i].constraints = RigidbodyConstraints.None;
                
            }
            for(int i = 0; i < boxCollider.Length; i++)
            {
                boxCollider[i].enabled = false;
            }

        }
    }
}
