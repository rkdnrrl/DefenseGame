using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ClientInstance : NetworkBehaviour
{

    
    public NetworkIdentity player;


    public override void OnStartServer()
    {
        base.OnStartServer();
        NetworkSpawnPlayer();
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        //UIManager.instance.score = ;
    }

    [Server]
    private void NetworkSpawnPlayer()
    {
        GameObject go = Instantiate(player.gameObject, transform.position, Quaternion.identity);
        NetworkServer.Spawn(go, base.connectionToClient);
    }
}
