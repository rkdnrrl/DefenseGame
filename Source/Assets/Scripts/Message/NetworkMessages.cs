using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class NetworkMessages
{       
    [Serializable]
    public struct PlayerJoinMessage : NetworkMessage
    {
        public string content;
    }
    [Serializable]
    public struct LogMessage : NetworkMessage
    {
        public string content;
    }
}
