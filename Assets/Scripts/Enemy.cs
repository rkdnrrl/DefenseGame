using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Enemy : NetworkBehaviour
{
    [SyncVar(hook = nameof(DT))]
    public float health = 1;

    public float damage;


    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }    


    [Server]
    private void FixedUpdate()
    {
        Vector3 dir = Castle.instance.transform.position - transform.position;
        dir.Normalize();
        rb.velocity = new Vector3(dir.x, rb.velocity.y,dir.z);
    }

    [Command(requiresAuthority = false)]
    public void Hurt(int damage)
    {
        health -= damage;
    }

    void DT(float oldHelath, float newHealth)
    {
        if (newHealth <= 0)
        {
            Castle.instance.CmdChangeMoney(15);
            NetworkServer.Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Castle castle = other.gameObject.GetComponent<Castle>();
        if(castle != null)
        {
            castle.CmdCastleHealth((int)-damage);
            Hurt((int)health);
        }

    }
}
