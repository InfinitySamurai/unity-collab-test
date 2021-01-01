using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public ParticleSystem particles;
    public PlayerData playerData;

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
            playerData.points.Value += collision.collider.gameObject.GetComponent<Ball>().ballType.pointValue.Value;
            Destroy(collision.collider.gameObject);
            particles.Play();
        }
    }
}
