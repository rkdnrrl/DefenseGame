using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEscUI : MonoBehaviour, IEscUI
{
    public EscUI escUI;

    public void Btn_Exit()
    {
        Application.Quit();
    }

    public void Btn_Setting()
    {
        escUI.SettingUI.SetActive(true);
    }

    public void Btn_Continue()
    {
        ControllerManager conM = Manager.instance.controllerManager;
        conM.VisibleEscUI();

    }
}
