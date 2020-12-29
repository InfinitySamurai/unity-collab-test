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
        if(upgradeCanvasVisible == false)
        {
            upgradeCanvas.enabled = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            upgradeCanvas.enabled = true;
            upgradeCanvasVisible = true;
        }else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            upgradeCanvas.enabled = false;
            upgradeCanvasVisible = false;
        }
    }
}
