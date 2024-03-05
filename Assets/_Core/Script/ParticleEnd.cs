using UnityEngine;

public class ParticleEnd : MonoBehaviour
{
    [SerializeField] private GameObject mainParticle;
    
    void Start()
    {
        var main = this.gameObject.GetComponent<ParticleSystem>().main;
        main.stopAction = ParticleSystemStopAction.Callback;
    }

    void OnParticleSystemStopped()
    {
        mainParticle.SetActive(false);   
    }
}