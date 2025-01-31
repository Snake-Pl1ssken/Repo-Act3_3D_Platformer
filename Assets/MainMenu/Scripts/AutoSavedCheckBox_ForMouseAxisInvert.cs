using Unity.Cinemachine;
using UnityEngine;

public class AutoSavedCheckBox_ForMouseAxisInvert : AutoSavedCheckBox
{

    private CinemachineFreeLook freeLookcamera;
    //private bool ejeInvertir;
    [SerializeField] string nameParametro;

    public override void InternalValueChanged(bool value)
    {
        bool isInverted = value;

        if (nameParametro == "Toggle_InvertMouseAxisX")
        {
            freeLookcamera.m_XAxis.m_InvertInput = isInverted;
        }
        else if (nameParametro == "Toggle_InvertMouseAxisY")
        {
            freeLookcamera.m_YAxis.m_InvertInput = isInverted;
        }
    }
}
