using System.Collections.Generic;
using UnityEngine;
using Mirror;

/*
	Documentation: https://mirror-networking.gitbook.io/docs/guides/networkbehaviour
	API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkBehaviour.html
*/

// NOTE: Do not put objects in DontDestroyOnLoad (DDOL) in Awake.  You can do that in Start instead.

public class Castle : NetworkBehaviour
{
    public static Castle instance;
    public float maxHelath = 100;


    [SyncVar]
    public float health = 100;

    [SyncVar]
    public int gold = 100;


    private void Awake()
    {
        if (instance != null)
            instance = null;

        instance = this;
    }

    private void Start()
    {
        SetCastleHealth((int)health);
    }

    private void Update()
    {
        EnvironmentManager envi = Manager.instance.environmentManager;
        envi.elapsedTime += Time.deltaTime;

        float elapsedTime = envi.elapsedTime;
        float nextAttackTime = envi.nextAttackTime;
        float timeLeft = envi.timeLeft;

        if (elapsedTime > nextAttackTime)
        {
            int damage = envi.damage;
            envi.nextAttackTime = (int)(elapsedTime + timeLeft);
            AttackCastle(-damage);
        }
    }

    #region Start & Stop Callbacks

    /// <summary>
    /// This is invoked for NetworkBehaviour objects when they become active on the server.
    /// <para>This could be triggered by NetworkServer.Listen() for objects in the scene, or by NetworkServer.Spawn() for objects that are dynamically created.</para>
    /// <para>This will be called for objects on a "host" as well as for object on a dedicated server.</para>
    /// </summary>
    public override void OnStartServer() { }

    /// <summary>
    /// Invoked on the server when the object is unspawned
    /// <para>Useful for saving object data in persistent storage</para>
    /// </summary>
    public override void OnStopServer() { }

    /// <summary>
    /// Called on every NetworkBehaviour when it is activated on a client.
    /// <para>Objects on the host have this function called, as there is a local client on the host. The values of SyncVars on object are guaranteed to be initialized correctly with the latest state from the server when this function is called on the client.</para>
    /// </summary>
    public override void OnStartClient() { }

    /// <summary>
    /// This is invoked on clients when the server has caused this object to be destroyed.
    /// <para>This can be used as a hook to invoke effects or do client specific cleanup.</para>
    /// </summary>
    public override void OnStopClient() { }

    /// <summary>
    /// Called when the local player object has been set up.
    /// <para>This happens after OnStartClient(), as it is triggered by an ownership message from the server. This is an appropriate place to activate components or functionality that should only be active for the local player, such as cameras and input.</para>
    /// </summary>
    public override void OnStartLocalPlayer() {
        
    
    }

    /// <summary>
    /// Called when the local player object is being stopped.
    /// <para>This happens before OnStopClient(), as it may be triggered by an ownership message from the server, or because the player object is being destroyed. This is an appropriate place to deactivate components or functionality that should only be active for the local player, such as cameras and input.</para>
    /// </summary>
    public override void OnStopLocalPlayer() {}

    /// <summary>
    /// This is invoked on behaviours that have authority, based on context and <see cref="NetworkIdentity.hasAuthority">NetworkIdentity.hasAuthority</see>.
    /// <para>This is called after <see cref="OnStartServer">OnStartServer</see> and before <see cref="OnStartClient">OnStartClient.</see></para>
    /// <para>When <see cref="NetworkIdentity.AssignClientAuthority">AssignClientAuthority</see> is called on the server, this will be called on the client that owns the object. When an object is spawned with <see cref="NetworkServer.Spawn">NetworkServer.Spawn</see> with a NetworkConnectionToClient parameter included, this will be called on the client that owns the object.</para>
    /// </summary>
    public override void OnStartAuthority() { }

    /// <summary>
    /// This is invoked on behaviours when authority is removed.
    /// <para>When NetworkIdentity.RemoveClientAuthority is called on the server, this will be called on the client that owns the object.</para>
    /// </summary>
    public override void OnStopAuthority() { }

    #endregion

    [Server]
    public void AttackCastle(int damage)
    {
        CmdCastleHealth(damage);
    }

    public void FixCastle(int value)
    {
        if (this.gold < 5)
            return;

        CmdChangeMoney(-5);
        CmdCastleHealth(value);
    }

    public void Hurt(int damage)
    {
        CmdCastleHealth(-damage);
    }


    //클라이언트에서 서버에게 쏴주는 거임 서버에만 적용이 됨
    [Command(requiresAuthority = false)]
    public void CmdCastleHealth(int damage,  NetworkConnectionToClient sender = null)
    {
        //Debug.Log("Cmd");
        RpcReceive(damage);
    }

    //서버가 클라이언트에게 나눠줌. 이걸 Command로 가서 ClientRpc를 호출하면 서버와 클라이언트 둘다 한테 주는걸로 됨
    [ClientRpc]
    void RpcReceive(int damage)
    {
        float health = this.health + damage;
        SetCastleHealth(health);
    }

    void SetCastleHealth(float health)
    {
        if (health > maxHelath)
            health = maxHelath;
        else if (health <= 0)
        {
            health = 0;
            ResultUI resultUI = Manager.instance.uiManager.resultUI;
            resultUI.Lose();
        }

        this.health = health;

        SetChangeValue();
    }    

    [Command(requiresAuthority = false)]
    public void CmdChangeMoney(int gold)
    {
        RpcMoney(gold);
    }

    [ClientRpc]
    void RpcMoney(int gold)
    {
        this.gold += gold;

        if (this.gold < 0)
            this.gold = 0;

        SetChangeValue();
    }

    void SetChangeValue()
    {
        CastleUI caslteUI = Manager.instance.uiManager.castleUI;
        if (caslteUI != null)
        {
            caslteUI.SetChangeValue();
        }
    }
}
