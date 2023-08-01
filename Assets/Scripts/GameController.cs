using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Board _board;
    public void Check(Label label, int number)
    {
        print(number);
        foreach (var item in _board.Cells.Where(item => item.GetLabel == label && item.GetText == number))
        {
            print(item.GetText);
            item.Clickable = true;
        }
    }

    private void Start()
    {
        _board.SetBoardData();
        Check(Label.I, _board.Cells[8].GetText);
    }
}
