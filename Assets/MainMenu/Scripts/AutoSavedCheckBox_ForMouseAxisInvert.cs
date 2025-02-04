using System.Runtime.CompilerServices;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class AutoSavedCheckBox_ForMouseAxisInvert : AutoSavedCheckBox
{
    [SerializeField] CinemachineInputAxisController inputAxisController;
    [SerializeField] Toggle flipX;
    [SerializeField] Toggle flipY;

    private void Start()
    {
        flipX.onValueChanged.AddListener(FlipXAxis);
        flipY.onValueChanged.AddListener(FlipYAxis);

        flipX.isOn = PlayerPrefs.GetInt("FlipXAxis", 0) == 1;
        flipY.isOn = PlayerPrefs.GetInt("FlipYAxis", 0) == 1;
    }

    public void FlipXAxis(bool isFlipped)
    {
        foreach (var controller in inputAxisController.Controllers)
        {
            if (controller.Name == "Look Orbit X")
            {
                controller.Input.Gain = isFlipped ? -Mathf.Abs(controller.Input.Gain) : Mathf.Abs(controller.Input.Gain);
            }
        }
        PlayerPrefs.SetInt("FlipXAxis", isFlipped ? 1 : 0);
    }

    public void FlipYAxis(bool isFlipped)
    {
        foreach (var controller in inputAxisController.Controllers)
        {
            if (controller.Name == "Look Orbit Y")
            {
                controller.Input.Gain = isFlipped ? -Mathf.Abs(controller.Input.Gain) : Mathf.Abs(controller.Input.Gain);
            }
        }
        PlayerPrefs.SetInt("FlipYAxis", isFlipped ? 1 : 0);
    }
}