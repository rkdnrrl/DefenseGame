using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerInteraction : CreatureInteraction
{

    private void Start()
    {
        //Camera.main.transform.position = play
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RayCast(entity);
        }
    }
}
