using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJoinMessageUI : MessageUI, IMessageUI
{    
    private NetworkMessages.PlayerJoinMessage playerMsg;
    public Text contentText;

    private void Start()
    {
        InitData();
    }

    public void InitData()
    {
        this.playerMsg = (NetworkMessages.PlayerJoinMessage)msg;
        Render();
    }

    public void Render()
    {
        contentText.text = this.playerMsg.content;
    }
}
