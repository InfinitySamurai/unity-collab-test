using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Sphere")
        {
            collision.rigidbody.AddForce(transform.up * 1000);
        }
    }
}
