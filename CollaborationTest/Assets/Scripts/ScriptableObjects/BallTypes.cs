using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BallTypes", menuName = "Data Store/BallTypes", order = 1)]
public class BallTypes : ScriptableObject
{
    public List<BallType> types;
}
