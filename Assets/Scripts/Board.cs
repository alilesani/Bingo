using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Cell[] _cells;
    private int[][] _data;

    private void Awake()
    {
        _data = GenerateData.GetData();
    }

    private void Start() {
        int index = 0;
        foreach (int[] row in _data)
        {
            foreach (int item in row)
            {
                _cells[index].SetText(item.ToString());
                index++;
            }
        }
    }
}
