using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    public GameObject upgradeNameObject;
    private Text upgradeNameText;

    public GameObject upgradeDescriptionObject;
    private Text upgradeDescriptionText;

    public GameObject costObject;
    private Text costText;

    // public upgrade scriptable object
    public Upgrade upgradeData;

    // Start is called before the first frame update
    void Start()
    {
        costText = costObject.GetComponent<Text>();
        upgradeNameText = upgradeNameObject.GetComponent<Text>();
        upgradeDescriptionText = upgradeDescriptionObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
