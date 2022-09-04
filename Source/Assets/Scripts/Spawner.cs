using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class Spawner : NetworkBehaviour
{
    public static Spawner ins;

    public Entity[] objects;

    public Text healthText;

}
