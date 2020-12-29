using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerData playerData;
    public CharacterController characterController;
    public float speed = 3;
    public int baseThrowPower = 100;
    public GameObject sphereTracker;

    // camera and rotation
    public Camera cameraHolder;
    
    public float mouseSensitivity = 2f;
    public float upLimit = -50;
    public float downLimit = 50;

    // gravity
    private float gravity = 9.87f;
    private float verticalSpeed = 0;

    // raycasting
    public float raycastLength = 200f;

    // inventory
    public Ball heldSphere;

    private void Start()
    {
    }

    void Update()
    {
        Move();
        Rotate();

        Debug.DrawRay(cameraHolder.transform.position, cameraHolder.transform.forward, Color.red, 1f, true);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit rayHit;
            bool didHit = Physics.Raycast(cameraHolder.transform.position, cameraHolder.transform.forward, out rayHit, raycastLength);

            if (heldSphere)
            {
                heldSphere.GetComponent<Rigidbody>().AddForce(cameraHolder.transform.forward * baseThrowPower * playerData.strength.Value);
                heldSphere = null;
            }
            else if (didHit && rayHit.collider && (!heldSphere))
            {
                var ballComponent = rayHit.collider.GetComponent<Ball>();
                if(ballComponent)
                {
                    heldSphere = ballComponent;
                }
            }

        }

        if(heldSphere)
        {
            heldSphere.transform.position = this.transform.position + cameraHolder.transform.forward * 2;
        }

        if( Input.GetKey(KeyCode.F))
        {
            Ball[] spheres =  sphereTracker.GetComponentsInChildren<Ball>();
            foreach (Ball sphere in spheres)
            {
                Vector3 spherePosition = sphere.GetComponent<Transform>().position;
                Rigidbody sphereRigidBody = sphere.GetComponent<Rigidbody>();

                Vector3 pushDirection = transform.position - spherePosition;
                Debug.DrawRay(spherePosition, pushDirection * 100, Color.red, 1f);
                  

                sphereRigidBody.AddForce(pushDirection);
            }
        }
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Rotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        transform.Rotate(0, horizontalRotation * mouseSensitivity, 0);
        cameraHolder.transform.Rotate(-verticalRotation * mouseSensitivity, 0, 0);

        Vector3 currentRotation = cameraHolder.transform.localEulerAngles;
        if (currentRotation.x > 180) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit);
        cameraHolder.transform.localRotation = Quaternion.Euler(currentRotation);
    }

    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        if (characterController.isGrounded) verticalSpeed = 0;
        else verticalSpeed -= gravity * Time.deltaTime;
        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);

        Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
        characterController.Move(speed * Time.deltaTime * move + gravityMove * Time.deltaTime);
    }
}