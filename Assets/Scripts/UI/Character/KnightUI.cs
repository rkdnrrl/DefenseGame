using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightUI : ClassUI
{
    public Text ammoText;

    public void SetChangeValue()
    {
        Player player = PlayerManager.localPlayer;

        if (player == null)
            return;

        ammoText.text = player.GetAmmo().ToString();
    }
}
