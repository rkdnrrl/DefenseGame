using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CreatureInteraction : NetworkBehaviour
{
    public Entity entity;

    [Command]
    public void Attack(Entity target,Entity caster)
    {
        Debug.Log("attack!");
        target.Hurt(((Creature)caster).damage);
    }

    public void RayCast(Entity caster)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            RayCastHit(hit, caster);
        }
    }

    public void RayCastHit(RaycastHit hit, Entity caster)
    {
        Entity hitCol = hit.collider.GetComponent<Entity>();
        if (hitCol != null)
        {
            Attack(hitCol, caster);
        }
    }
}
