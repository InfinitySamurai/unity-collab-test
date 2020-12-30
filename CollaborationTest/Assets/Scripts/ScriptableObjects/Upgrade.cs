using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : ScriptableObject
{
    public string upgradeName;
    public string upgradeDescription;
    public IntReference upgradeBaseCost;
    public IntReference upgradeNextLevelCost;
    public IntReference upgradeLevel;
    public AnimationCurve upgradeCurve;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
