using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private string sceneName;

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        FindObjectOfType<TransfereData>().Fuite(sceneName);
    }

    private void OnEnable() 
    {
        restartButton.Select();
    }
}