using UnityEngine;
using UnityEngine.UI;

public class ButtonTitleScreen : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject creditsScreen;
    [SerializeField] private GameObject storyScreen;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button attackButton;
    [SerializeField] private Button storyButton;
    public void UIButtonStart()
    {
        titleScreen.SetActive(false);
        storyScreen.SetActive(true);
        storyButton.Select();

    }
    public void UICredits()
    {
        titleScreen.SetActive(false);
        creditsScreen.SetActive(true);
        creditsButton.Select();
    }
    public void QuitCredit()
    {
        creditsScreen.SetActive(false);
        titleScreen.SetActive(true);
        attackButton.Select();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void UIStoryScreen()
    {
        FindObjectOfType<TransfereData>().ChangeScene("MAP FOREST");
    }
}
