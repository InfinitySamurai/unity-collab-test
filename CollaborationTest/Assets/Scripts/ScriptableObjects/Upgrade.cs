using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Data Store/Upgrade", order = 1)]
public class Upgrade : ScriptableObject
{
    public string upgradeName;
    public string upgradeDescription;
    public IntReference upgradeBaseCost;
    public IntReference upgradeNextLevelCost;
    public IntReference upgradeLevel;
    public ExponentialCurve upgradeCurve;
    public PlayerData playerData;

    public void Purchase()
    {
        // subtract current cost from players points
        playerData.points.Value -= upgradeNextLevelCost.Value;

        // increase level of the upgrade
        upgradeLevel.Value++;

        //set the new cost based on the curve
        float curveValue = upgradeCurve.GetValue(upgradeLevel.Value);
        Debug.Log("Curve Value is " + curveValue);
        upgradeNextLevelCost.Value = Mathf.CeilToInt(upgradeBaseCost.Value * curveValue);

        Debug.Log("Upgraded " + upgradeName + " new cost is " + upgradeNextLevelCost.Value + " level is " + upgradeLevel.Value);
    }
}
