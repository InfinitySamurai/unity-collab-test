using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rigidBody;
    public BallType ballType;
    
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        this.gameObject.tag = "Sphere";
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.material = ballType.material;
    }

    public void setDefaults(BallType type)
    {
        this.ballType = type;
    }

    // Update is called once per frame
    void Update()
    {
        if(rigidBody.position.y < -100)
        {
            Destroy(this.gameObject);
        }
    }
}
