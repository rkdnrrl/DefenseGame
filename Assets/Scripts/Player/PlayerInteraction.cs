using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerInteraction : NetworkBehaviour
{
    public Player player;

    public float weaponRange = 5;

    private void Start()
    {
        if (!hasAuthority) return;

        ControllerManager conM = Manager.instance.controllerManager;
        conM.MouseVisible(false);
    }

    private void Update()
    {
        if (!hasAuthority)
            return;

        RayCast();
    }


    void RayCast()
    {
        if (!player.UserCheck())
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            

            RaycastHit hit;

            Transform cameraPos = Camera.main.transform;

            if (Physics.Raycast(cameraPos.position, cameraPos.forward, out hit, weaponRange))
            {
                ClickObject(hit);
            }
        }
    }
    void ClickObject(RaycastHit hit)
    {
        if (player.GetCharacterClass() == CharacterClass.KING) KingClick(hit);
        else if (player.GetCharacterClass() == CharacterClass.KNIGHT) KnightClick(hit);
    }

    void KnightClick(RaycastHit hit)
    {
        Attack(hit);
        
    }

    void Attack(RaycastHit hit)
    {
        if (player.GetAmmo() <= 0)
            return;

        Enemy enemy = hit.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            player.CmdSetAmmo(-1);
            enemy.Hurt(1);
        }
    }

    void KingClick(RaycastHit hit)
    {
        Castle castle = hit.collider.GetComponent<Castle>();
        if (castle != null)
        {
            castle.FixCastle(player.GetDamage());
        }

        Player targetPlayer = hit.collider.GetComponent<Player>();
        if (targetPlayer != null)
        {
            targetPlayer.Reroad(1);
        }
    }

}
