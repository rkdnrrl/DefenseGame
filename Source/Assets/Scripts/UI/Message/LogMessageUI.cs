using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class LogMessageUI : MessageUI, IMessageUI
{
    private NetworkMessages.LogMessage logMessage;
    public Text contentText;

    private void Start()
    {
        InitData();
    }

    public void InitData()
    {
        this.logMessage = (NetworkMessages.LogMessage)msg;
        Render();
    }

    public void Render()
    {
        contentText.text = this.logMessage.content;
    }


}
