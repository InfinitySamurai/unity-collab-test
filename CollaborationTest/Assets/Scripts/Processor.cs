using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Processor : MonoBehaviour
{
    public GameObject collecter;
    public GameObject dispenser;

    public int maxItemsInStorage;
    public int dispenseTimeoutSeconds;

    private float countdown = 0;
    private Queue<GameObject> storage = new Queue<GameObject>();



    // Start is called before the first frame update
    void Start()
    {
        collecter.tag = "Collecter";
        dispenser.tag = "Dispenser";
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown < 0)
        {
            countdown = dispenseTimeoutSeconds;
            handleDispense();
        }
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

            //do something with it
            if(storage.Count < maxItemsInStorage)
            {
                GameObject ball = collision.gameObject;
                ball.SetActive(false);
                storage.Enqueue(ball);
            }
        }
    }

    private void handleDispense()
    {
        if(storage.Count > 0)
        {
            GameObject sphere = storage.Dequeue();
            sphere.SetActive(true);
            Rigidbody sphereRigid = sphere.GetComponent<Rigidbody>();
            sphere.transform.position = dispenser.transform.position + (dispenser.transform.forward);
            sphereRigid.velocity = Vector3.zero;
            sphereRigid.AddForce(dispenser.transform.forward * 500);
        }
    }
}
