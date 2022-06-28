using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IEscUI
{
    void Btn_Exit();
}

public class EscUI : MonoBehaviour
{
    public GameObject mainEscUI;
    public GameObject SettingUI;

    public void Show(bool visible)
    {
        ControllerManager keyboard = Manager.instance.controllerManager;
        keyboard.MouseVisible(!visible);
        VisibleWin(!visible);        
    }


    void VisibleWin(bool visible)
    {
        mainEscUI.gameObject.SetActive(visible);
    }

    
}
