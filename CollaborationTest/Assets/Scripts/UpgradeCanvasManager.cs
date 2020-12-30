using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCanvasManager : MonoBehaviour
{

    public PlayerData playerData;
    public GameObject upgradePrefab;
    public GameObject storePanel;

    public float startX = 25f;
    public float startY = -30f;
    public float ySeperation = -30f;
    public Vector3 panelStartVector = new Vector3(0, 100f, 0);
    public Vector3 panelSeperationVector = new Vector3(0, 100f, 0);

    // Include some reference to the upgrade list here

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; i += 1)
        {
            GameObject upgradePanel = Instantiate(upgradePrefab);
            upgradePanel.transform.SetParent(storePanel.transform, false);

            RectTransform rectTransform = upgradePanel.GetComponent<RectTransform>();
            rectTransform.offsetMin = new Vector2(40f, -40f);
            rectTransform.offsetMax = new Vector2(-40f, 60f);
            rectTransform.position -= panelStartVector + i * panelSeperationVector;
        }
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
