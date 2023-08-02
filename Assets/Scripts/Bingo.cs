using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bingo : MonoBehaviour
{

    public bool CheckStatus(Cell[] cells)
    {
        return HorizontalBingo(cells) || VerticalBingo(cells) || DiameterBingo(cells) || VertexBingo(cells);
    }

    private bool HorizontalBingo(Cell[] cells)
    {
        for (int i = 0; i < cells.Length; i += 5)
        {
            if (IsBingo(cells[i..(i + 5)])) return true;
        }
        return false;
    }
    private bool VerticalBingo(Cell[] cells)
    {
        for (int i = 0; i < 5; i++)
        {
            Cell[] columns = new Cell[5];
            for (int j = 0; j < 25; j += 5)
            {
                columns[j / 5] = cells[i + j];
            }
            if (IsBingo(columns)) return true;
        }
        return false;
    }
    private bool DiameterBingo(Cell[] cells)
    {
        Cell[] posetiveDiameter = new Cell[5];
        Cell[] negativeDiameter = new Cell[5];
        for (int i = 0; i < 5; i++)
        {
            posetiveDiameter[i] = cells[(5 + 1) * i];
            negativeDiameter[i] = cells[(5 - 1) * (5 - i)];
        }
        if (IsBingo(posetiveDiameter) || IsBingo(negativeDiameter)) return true;
        return false;
    }
    private bool VertexBingo(Cell[] cells)
    {
        Cell[] X = { cells[0], cells[4], cells[12], cells[20], cells[24] };
        return IsBingo(X);
    }
    private bool IsBingo(Cell[] cells)
    {
        bool result = true;
        foreach (Cell cell in cells)
        {
            result &= cell.HasRead && !cell.Clickable;
        }
        return result;
    }
}
