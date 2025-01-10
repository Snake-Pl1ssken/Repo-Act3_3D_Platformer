using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
