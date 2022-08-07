using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using System;

public interface IMessageUI
{
    void InitData();
    void Render();
}
public class MessageUI : MonoBehaviour
{
    [SerializeField] protected float destroyTime = 2f;
    protected NetworkMessage msg;

    public virtual void CreateUI<T>(T msg) where T : NetworkMessage
    {
        MessageManager mM = MessageManager.singleton;
        GameObject ui = Instantiate(mM.GetMessageUI<T>());
        ui.GetComponent<MessageUI>().GetMsg(msg);
    }

    public void GetMsg<T>(T msg) where T : NetworkMessage
    {
        this.msg = msg;
        Destroy(gameObject, destroyTime);
    }

    
}
