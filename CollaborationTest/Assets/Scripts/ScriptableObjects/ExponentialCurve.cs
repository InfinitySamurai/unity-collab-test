using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExponentialCurve", menuName = "Curves/Exponential", order = 1)]
public class ExponentialCurve : ScriptableObject
{
    public float difficulty = 0.01f;
    private float c = 1;

    public float GetValue(float x)
    {
        float d = 1 - c;
        return c * Mathf.Exp(x / difficulty) + d;
    }
}
