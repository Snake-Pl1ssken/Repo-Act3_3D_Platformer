using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
   // public static MenuPausa instance { get; private set; }

    [Header("Input Actions Pause")]
    [SerializeField] private InputActionReference pause;
    [SerializeField] private CanvasGroup pauseScreen;

    private bool isPaused = false;

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //}

    private void OnEnable()
    {
        pause.action.Enable();
    }

    private void Start()
    {
        SetPauseScreen(0f, false);
    }

    private void Update()
    {
        if (pause.action.WasPressedThisFrame())
        {
            TogglePause();
        }
    }

    private void OnDisable()
    {
        pause.action.Disable();
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        SetPauseScreen(isPaused ? 1f : 0f, isPaused);
    }

    public void BotonResume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SetPauseScreen(0f, false);
    }

    //public void BotonRestart()
    //{
    //    isPaused = false;
    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}

    //public void BotonMainMenu()
    //{
    //    isPaused = false;
    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene("Main_Menu");
    //}

    private void SetPauseScreen(float alpha, bool interactable)
    {
        pauseScreen.alpha = alpha;
        pauseScreen.interactable = interactable;
        pauseScreen.blocksRaycasts = interactable;
    }
}
