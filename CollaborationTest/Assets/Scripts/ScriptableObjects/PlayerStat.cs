﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "PlayerStat", menuName = "Data Store/PlayerStat", order = 1)]
public class PlayerStat: ScriptableObject
{
    public List<Upgrade> Modifiers;


    [SerializeField]
    public float Value
    {
        get
        {
            float total = 1;
            Modifiers.ForEach(mod =>
            {
                if(mod.type == Upgrade.UPGRADE_TYPES.ADDER)
                {
                    total += mod.upgradeLevel.Value;
                }else if(mod.type == Upgrade.UPGRADE_TYPES.MULTIPLIER)
                {
                    total *= mod.upgradeLevel.Value;
                }
            });
            return total;
        }
        set {
            Value = value;
        }
    }
}
