using System.Collections;
using System.Collections.Generic;
using System;

public static class ExtensionMethod
{
    #region 게임 알고리즘
    private static Random rng = new Random();
    public static void Shuffle<T>(this List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    #endregion
}
