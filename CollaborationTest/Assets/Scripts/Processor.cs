using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Processor : MonoBehaviour
{
    public GameObject collecter;
    public GameObject dispenser;
    private List<Ball> storage;

    public int maxItemsInStorage;


    // Start is called before the first frame update
    void Start()
    {
        collecter.tag = "Collecter";
        dispenser.tag = "Dispenser";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.GetContact(0).thisCollider;
        //something hit the collector GameObject
        if(collider.gameObject.tag == "Collecter")
        {
            handleCollectorCollision(collision);
        }
    }

    private void handleCollectorCollision(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Sphere")
        {
            GameObject sphere = collision.collider.gameObject;
            Rigidbody sphereRigid = sphere.GetComponent<Rigidbody>();
            //a sphere hit the collector
            Debug.Log("We have contact!");
            //do something with it
            sphere.transform.position = dispenser.transform.position + (dispenser.transform.forward);
            sphereRigid.velocity = Vector3.zero;
            sphereRigid.AddForce(dispenser.transform.forward * 500);
        }
    }
}
