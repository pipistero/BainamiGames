using System;
using UnityEngine;

public static class VectorExtensions
{
    public static Vector3 AddVector2(this Vector3 vector3, Vector2 vector2)
    {
        return new Vector3(vector3.x + vector2.x, vector3.y + vector2.y, vector3.z);
    }

    public static Vector3 Clamp(this Vector3 vector, Vector3 minValue, Vector3 maxValue)
    {
        var xValue = Math.Clamp(vector.x, minValue.x, maxValue.x);
        var yValue = Math.Clamp(vector.y, minValue.y, maxValue.y);
        var zValue = Math.Clamp(vector.z, minValue.z, maxValue.z);

        return new Vector3(xValue, yValue, zValue);
    }
}