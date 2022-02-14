using UnityEngine;
using System.Collections.Generic;

public static class Utility {
    private static System.Random seed = new System.Random();

    ///<summary>
    /// Shuffles a Generic List based on a Random seed.
    /// Use Array.ToList() to shuffle arrays.
    ///</summary>
    public static void Shuffle<T>(this IList<T> list) {
        int n = list.Count - 1;

        for (int i = n; i != 0; i--) {
            int k = seed.Next(n);

            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
