using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MainEscUI : MonoBehaviour, IEscUI
{
    public EscUI escUI;

    public void Btn_Exit()
    {
        Player player = PlayerManager.localPlayer;
        if(player.isServer)
            NetworkRoomManager.singleton.StopHost();
        else
            NetworkRoomManager.singleton.StopClient();
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
