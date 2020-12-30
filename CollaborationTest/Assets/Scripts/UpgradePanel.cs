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

    public Button purchaseButton;

    // public upgrade scriptable object
    public Upgrade upgrade;

    // Start is called before the first frame update
    void Start()
    {
        costText = costObject.GetComponent<Text>();
        upgradeNameText = upgradeNameObject.GetComponent<Text>();
        upgradeDescriptionText = upgradeDescriptionObject.GetComponent<Text>();
        purchaseButton.onClick.AddListener(upgrade.Purchase);
    }

    // Update is called once per frame
    void Update()
    {
        purchaseButton.interactable = upgrade.canPurchase();
        costText.text = upgrade.upgradeNextLevelCost.Value.ToString();
        upgradeNameText.text = upgrade.upgradeName;
        upgradeDescriptionText.text = upgrade.upgradeDescription;
    }
}
