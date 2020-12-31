using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data Store/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public FloatReference points;
    public PlayerStat strength;
    public PlayerStat speed;
}
