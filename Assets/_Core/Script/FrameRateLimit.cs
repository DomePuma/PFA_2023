using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateLimit : MonoBehaviour
{
    [SerializeField] private float framerate = 60;

    public void timeScaleDown()
    {
        Time.timeScale -= 0.1f;
    }
    public void timeScaleUp()
    {
        Time.timeScale += 0.1f;
    }
    public void timeScaleNormal()
    {
        Time.timeScale = 1f;
    }
    private void Awake()
    {
        Application.targetFrameRate = (int)framerate;
    }
}