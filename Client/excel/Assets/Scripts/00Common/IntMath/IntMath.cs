using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class IntMath
{
    public static long Clamp(long a, long min, long max)
    {
        if (a < min)
        {
            return min;
        }
        if (a > max)
        {
            return max;
        }
        return a;
    }
}