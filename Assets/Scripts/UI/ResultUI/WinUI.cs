using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUI : MonoBehaviour, IResult
{
    public void Show()
    {
        gameObject.SetActive(true);
    }
}
