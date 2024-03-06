using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject guideDesAventuriersScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject commandScreen1;
    [SerializeField] private GameObject commandScreen2;
    [SerializeField] private GameObject uI;
    [SerializeField] private Button guideDesAventuriersScreenButton;
    [SerializeField] private Button guideDesAventuriersButton;
    [SerializeField] private Button commandScreen1Button;
    [SerializeField] private Button commandScreen2Button;
    [SerializeField] private Button returnButton;

    public static Action<bool> DeactivateInputAction;

    private void OnEnable() 
    {
        Time.timeScale = 0f;
        guideDesAventuriersButton.Select();
        Cursor.lockState = CursorLockMode.None;
        DeactivateInputAction?.Invoke(false);
    }
    
    private void OnDisable() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        DeactivateInputAction?.Invoke(true);
    }
    
    public void GuideDesAventuriers()
    {
        pauseScreen.SetActive(false);
        guideDesAventuriersScreen.SetActive(true);
        guideDesAventuriersScreenButton.Select();
    }
    
    public void QuitGuide()
    {
        guideDesAventuriersScreen.SetActive(false);
        pauseScreen.SetActive(true);
        returnButton.Select();
    }
    
    public void CommandsPart1()
    {
        pauseScreen.SetActive(false);
        commandScreen1.SetActive(true);
        commandScreen1Button.Select();
    }
    
    public void CommandsPart2()
    {
        commandScreen1.SetActive(false);
        commandScreen2.SetActive(true);
        commandScreen2Button.Select();
    }
    
    public void QuitCommands()
    {
        commandScreen2.SetActive(false);
        pauseScreen.SetActive(true);
        returnButton.Select();
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void Return()
    {
        uI.SetActive(false);
    }
}
