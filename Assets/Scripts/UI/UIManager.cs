using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class UIManager : MonoBehaviour
{
    public CastleUI castleUI;
    public PlayerUI playerUI;
    public EscUI escUI;
    public ResultUI resultUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //escUI.gameObject
        }
    }


    

}
