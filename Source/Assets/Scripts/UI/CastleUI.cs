using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class CastleUI : MonoBehaviour
{
    public Text healthText;
    public Text goldText;

    public void SetChangeValue()
    {
        Castle castle = Castle.instance;

        if (castle == null)
            return;

        healthText.text = castle.health.ToString();
        goldText.text = castle.gold.ToString();
    }
}
