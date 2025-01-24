using UnityEngine;
using UnityEngine.UI;
public class AutoSavedSlider : MonoBehaviour
{
    string savedSlider;
    float initialValue;

    private Slider slider;

    public virtual void InternalValueChanged(float value)
    {

    }

    void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat(savedSlider, initialValue);
        slider.onValueChanged.AddListener(onSliderValueChanged);

        //Cambiar el Slider value por el valor recuperado de playerprefs: savedSlider
    }


    void start()
    {
        InternalValueChanged(initialValue);
    }
    private void onSliderValueChanged(float value)
    {
        PlayerPrefs.SetFloat(savedSlider, initialValue);
        PlayerPrefs.Save();

        InternalValueChanged(initialValue);
    }
}
