using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[RequireComponent(typeof(CreatureMoveController))]
[RequireComponent(typeof(CreatureInteraction))]
public class Creature : Entity
{
    [SyncVar]
    public float damage;

    
}
