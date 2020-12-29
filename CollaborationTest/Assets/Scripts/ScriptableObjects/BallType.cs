using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BallType", menuName = "Data Store/BallType", order = 1)]
public class BallType : ScriptableObject
{
    public IntReference pointValue;
    public Material material;
}
