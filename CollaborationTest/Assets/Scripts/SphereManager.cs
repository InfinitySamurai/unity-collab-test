using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour
{
    public GameObject spherePrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spherePrefab, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
