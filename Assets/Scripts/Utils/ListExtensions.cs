using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class ListExtensions
{

    public static T GetRandom<T>(this IList<T> list)
    {
        int index = Random.Range(0, list.Count);
        return list[index];
    }

    public static void Shuffle<T>(this IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }

    public static Vector3 AbsVector3(this Vector3 vector3)
    {
        return new Vector3(Mathf.Abs(vector3.x), Mathf.Abs(vector3.y));
    }


}