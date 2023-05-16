using System.Collections.Generic;
using UnityEngine;

public class Roulette
{
    public T Run<T>(Dictionary<T, int> dic)
    {
        var total = 0;
        foreach (var item in dic)
        {
            total += item.Value;
        }

        var random = Random.Range(0, total);

        foreach (var item in dic)
        {
            random -= item.Value;
            if (random < 0)
            {
                return item.Key;
            }
        }

        return default(T);
    }
}