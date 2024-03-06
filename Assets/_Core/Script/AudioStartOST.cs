using UnityEngine;

public class AudioStartOST : MonoBehaviour
{
    [SerializeField] private AudioSource ost;

    private void Start()
    {
        ost.Play();
    }

}
