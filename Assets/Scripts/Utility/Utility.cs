using UnityEngine;
using System.Collections.Generic;

public static class Utility {
    private static System.Random seed = new System.Random();

    ///<summary>
    /// Shuffles a Generic List based on a Random seed.
    /// Use Array.ToList() to shuffle arrays.
    ///</summary>
    public static List<T> Shuffle<T>(this IList<T> list) {
        int n = list.Count;

        while (n > 1) {
            n--;
            int k = seed.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }

        return list as List<T>;
    }
}
