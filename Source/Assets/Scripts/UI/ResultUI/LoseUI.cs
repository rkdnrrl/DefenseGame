using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseUI : MonoBehaviour, IResult
{
    public void Show()
    {
        gameObject.SetActive(true);
    }


    public void Restart()
    {

    }
}
