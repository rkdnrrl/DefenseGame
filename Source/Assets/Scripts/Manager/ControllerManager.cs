using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ControllerManager : NetworkBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            VisibleEscUI();
    }

    public void VisibleEscUI()
    {
        EscUI esc = Manager.instance.uiManager.escUI;
        esc.Show(esc.mainEscUI.gameObject.activeSelf);
    }

    public void MouseVisible(bool visible)
    {
        
        if (visible)
            Cursor.lockState =  CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;

    }
}
