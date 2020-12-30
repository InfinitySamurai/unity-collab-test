using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject pointDisplay;
    public Canvas upgradeCanvas;
    public PlayerData playerData;
    private TextMeshProUGUI textMesh;
    private bool upgradeCanvasVisible;

    private void OnEnable()
    {
        textMesh = pointDisplay.GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        upgradeCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.KeyDownCheck();
        textMesh.SetText(playerData.points.Value.ToString());
    }

    private void KeyDownCheck()
    {
        if (Input.GetKeyDown("tab"))
        {
            ToggleUpgradeCanvas();
        }
    }

    private void ToggleUpgradeCanvas()
    {
        upgradeCanvas.enabled = !upgradeCanvas.enabled;
        Cursor.visible = !Cursor.visible;
        Cursor.lockState = Cursor.lockState == CursorLockMode.Confined ? CursorLockMode.Locked : CursorLockMode.Confined; ;
    }
}
