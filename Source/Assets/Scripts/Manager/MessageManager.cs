using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using System.Reflection;

/// <summary>
/// �޼����� ������.
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
                Debug.LogError("UI�� ����ֽ��ϴ�.");
                continue;
            }

            if (messageUIs[i].name == $"{choiseUIName}UI")
                choiseUI = messageUIs[i];
        }
        return choiseUI.gameObject;
    }


}
