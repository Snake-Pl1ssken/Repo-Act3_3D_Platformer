using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject canvasMainMenu;
    [SerializeField] GameObject canvasSettings;
    
    public void SwitchScene()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SettingsGame()
    {
        canvasMainMenu.SetActive(false);
        canvasSettings.SetActive(true);
    }

    public void BackMainMenu()
    {
        canvasMainMenu.SetActive(true);
        canvasSettings.SetActive(false);
    }
}
