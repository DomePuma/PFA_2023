using UnityEngine;
using UnityEngine.SceneManagement;

public class Artefact : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Weapon") SceneManager.LoadScene("EndScene");
    }
}