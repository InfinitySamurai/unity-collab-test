using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCanvasManager : MonoBehaviour
{

    public PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyStrength()
    {
        playerData.points.Value--;
        playerData.strength.Value++;
        Debug.Log("Bought strength");
    }
}
