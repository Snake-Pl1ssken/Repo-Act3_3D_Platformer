using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static MenuPausa instance
    {
        get; private set;
    }

    [Header("Input Actions Pause")]
    [SerializeField] InputActionReference pause;
    [SerializeField] GameObject pauseScreen;


    bool pauseState = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void OnEnable()
    {
        pause.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (pause.action.WasPressedThisFrame() && !pauseState)
        {
            // Debug.Log("saltando");
            pauseScreen.SetActive(true);
            //Time.timeScale = 0f;
            pauseState = true;
        }
        else if (pause.action.WasPressedThisFrame() && pauseState)
        {
            pauseScreen.SetActive(false);
           // pauseState = false;
            Time.timeScale = 1f;
        }
    }

    void OnDisable()
    {
        pause.action.Disable();
    }

    public void botonResume()
    {
        pauseScreen.SetActive(false);
        pauseState = false;
        Time.timeScale = 1f;
    }
    public void botonRestart()
    {
        pauseState = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void botonMainMenu()
    {
        pauseState = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Menu");
    }

    //public void PerderVida()
    //{
    //    vidas -= 1;
    //    hud.DesactivarVida(vidas);

    //    if (vidas == 0)
    //    {
    //        SceneManager.LoadScene("Main_Menu");
    //    }

    //}

    //public bool RecuperarVida()
    //{

    //    if (vidas == 3)
    //    {
    //        return false;
    //    }

    //    hud.ActivarVida(vidas);
    //    vidas += 1;

    //    return true;
    //}
}