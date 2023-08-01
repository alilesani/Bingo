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
            result[i - 1] = rnd;
            while (Array.Exists(result, el => el == rnd))
            {
                rnd = UnityEngine.Random.Range(start, finish);

            }
        }
        return result;
    }

    public static int[][] GetData()
    {
        for (int i = 0; i < 5; i++)
        {
            _randoms[i] = RangeRandomGenerator(5, 1 + (i * 15), 15 + (i * 15));
        }
        return _randoms;
    }
}
