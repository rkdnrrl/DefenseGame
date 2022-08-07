using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using System.Reflection;

/// <summary>
/// 메세지를 생성함.
/// </summary>
public class MessageManager : MonoBehaviour
{
    public static MessageManager singleton;

    public MessageUI[] messageUIs;

    private void Awake()
    {
        singleton = this;
        DontDestroyOnLoad(gameObject);
        NetworkClient.RegisterHandler<NetworkMessages.PlayerJoinMessage>(CreateMessageUI);
        NetworkClient.RegisterHandler<NetworkMessages.LogMessage>(CreateMessageUI);

    }

    public void CreateMessageUI<T>(T msg) where T : NetworkMessage
    {
        MessageUI messageUi = new MessageUI();
        messageUi.CreateUI(msg);
    }

    public GameObject GetMessageUI<T>()
    {
        MessageUI choiseUI = null;
        string choiseUIName = typeof(T).Name;
        for (int i = 0; i < messageUIs.Length; i++)
        {
            if (messageUIs[i] == null)
            {
                Debug.LogError("UI가 비어있습니다.");
                continue;
            }

            if (messageUIs[i].name == $"{choiseUIName}UI")
                choiseUI = messageUIs[i];
        }
        return choiseUI.gameObject;
    }


}
