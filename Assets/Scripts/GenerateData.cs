using System.Collections.Generic;
using System.Linq;
using System;
public class GenerateData
{
    private static int[][] _randoms = new int[5][];

    private static int[] RangeRandomGenerator(int count, int start, int finish)
    {
        int[] result = new int[count];
        int rnd;

        for (int i = count; i > 0; i--)
        {
            rnd = UnityEngine.Random.Range(start, finish);
            while (Array.Exists(result, el => el == rnd))
            {
                rnd = UnityEngine.Random.Range(start, finish);

            }
            result[i - 1] = rnd;
        }
        return result;
    }

    public static int[][] GetData()
    {
        for (int i = 0; i < 5; i++)
        {
            _randoms[i] = RangeRandomGenerator(5, 1 + (i * 15), 16 + (i * 15));
        }
        return _randoms;
    }

    public static List<Turn> CreateBag()
    {
        List<Turn> result = new List<Turn>();
        int index = 0;
        foreach (var label in Enum.GetValues(typeof(Label)).Cast<Label>())
        {
            for (int number = 1 + (index * 15); number < 16 + (index * 15); number++)
            {
                result.Add(new Turn(label, number) );
            }
            index++;
        }

        return result;
    }


}
