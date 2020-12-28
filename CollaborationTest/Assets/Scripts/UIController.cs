using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject pointDisplay;
    public PlayerData playerData;
    private TextMeshPro textMesh;

    private void OnEnable()
    {
        textMesh = pointDisplay.GetComponent<TextMeshPro>();
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
