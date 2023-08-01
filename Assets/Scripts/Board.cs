using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Board : MonoBehaviour
{
    [SerializeField] private GameObject[] _cells;

    private void Start()
    {
        
    }

    private int[] RangeRandomGenerator(int count, int start, int finish)
    {
        int[] result = new int[count];
        int rnd;
        do
        {
            rnd = UnityEngine.Random.Range(start, finish);
            result[count - 1] = rnd;
        } while (count > 0 && !Array.Exists(result, el => el == rnd));
        return result;
    }


}
