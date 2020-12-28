using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject pointDisplay;
    public SOPlayerSystem playerData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointDisplay.GetComponent<TextMeshPro>().SetText(playerData.points.ToString());
    }
}
