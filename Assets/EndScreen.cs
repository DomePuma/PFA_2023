using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject creditScreen;
    [SerializeField] private Button quitGame;
    [SerializeField] private Button reloadGame;

    public void EndScreenGame()
    {
        endScreen.SetActive(false);
        creditScreen.SetActive(true);
        quitGame.Select();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
