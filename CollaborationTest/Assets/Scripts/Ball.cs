using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rigidBody;

    public float puntStrength = 10;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void punt(Vector3 direction)
    {
        if(rigidBody)
        {
            rigidBody.velocity = direction * puntStrength;
        }
    }
}
