using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Board : MonoBehaviour
{
    [SerializeField] private Cell[] _cells;
    [SerializeField] private GameObject _win;
    private int[][] _data;

    public Cell[] Cells
    {
        get
        {
            return _cells;
        }
    }
    private void Awake()
    {
        _data = GenerateData.GetData();
    }

    public void SetBoardData()
    {
        int index = 0;
        foreach (int[] row in _data)
        {
            foreach (int item in row)
            {
                _cells[index].Number = item;
                index++;
            }
        }
    }

    public void SetAsWin() {
        _win.SetActive(true);
        foreach (Cell cell in _cells)
        {
            cell.Clickable = false;
        }
    }
}
