using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeList", menuName = "Data Store/Upgrade List", order = 1)]
public class UpgradeList : ScriptableObject
{
    public List<Upgrade> upgrades;
}
