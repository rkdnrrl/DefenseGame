using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour, IEscUI
{
    public Slider fieldOfViewSlider;
    public Text fieldOfViewValueText;

    public void Btn_Exit()
    {
        gameObject.SetActive(false);
    }

    public void FieldOfViewChange()
    {
        float calcValue = (fieldOfViewSlider.value * 179);
        Camera cam = Camera.main;
        cam.fieldOfView = calcValue;
        fieldOfViewValueText.text = ((int)calcValue).ToString();
    }
}
