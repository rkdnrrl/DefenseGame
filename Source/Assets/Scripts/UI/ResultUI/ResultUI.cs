using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IResult
{
    void Show();
}
public class ResultUI : MonoBehaviour
{
    public WinUI winUI;
    public LoseUI loseUI;


    public void Lose()
    {
        loseUI.Show();
    }

    public void Win()
    {
        winUI.Show();
    }

}
