using System.Runtime.CompilerServices;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Audio;

public class AutoSavedSlider_ForMouseAxisSensitivity : AutoSavedSlider
{
    public CinemachineFreeLook freeLookcamera;
    private bool isAxisX;
    private float multiplicadorMax;
    private float multiplicadorMin;


    public override void InternalValueChanged(float value)
    {
        float interpolatedValue = Mathf.Lerp(multiplicadorMin, multiplicadorMax, value);

        if (isAxisX)
        {
           freeLookcamera.m_XAxis.m_MaxSpeed = interpolatedValue;
        }
        else if (!isAxisX)
        {
           freeLookcamera.m_YAxis.m_MaxSpeed = interpolatedValue;
        }
    }
}


//Convertir el gain del cinemachin input axis controller, buscar mathf.sign que devuelve o 1 o -1 dependiendo del valor de un numero