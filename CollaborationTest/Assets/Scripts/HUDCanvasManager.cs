using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDCanvasManager : MonoBehaviour
{
    public GameObject pointDisplay;
    public PlayerData playerData;
    private TextMeshProUGUI textMesh;

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
        textMesh.SetText(playerData.points.Value.ToString());
    }
}
