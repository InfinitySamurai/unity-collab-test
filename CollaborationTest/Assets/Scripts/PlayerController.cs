using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 3;

    // camera and rotation
    public Camera cameraHolder;
    //public Transform cameraHolder;
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

    public abstract class Command
    {
        public abstract void Execute();
    }

    public class JumpFunction : Command
    {
        public override void Execute()
        {
            Jump();
        }
    }

    public static void Jump()
    {
        
    }

    public static void DoMove()
    {
        Command keySpace = new JumpFunction();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            keySpace.Execute();
        }

    }



    void Update()
    {
        Move();
        Rotate();

        Debug.DrawRay(cameraHolder.transform.position, cameraHolder.transform.forward);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit rayHit;
            bool didHit = Physics.Raycast(cameraHolder.transform.position, cameraHolder.transform.forward, out rayHit, raycastLength);

            if (heldSphere)
            {
                heldSphere.punt(cameraHolder.transform.forward * 10);
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

    //private void OnMouseDown()
    //{
    //    RaycastHit ray;
    //    bool didHit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out ray, raycastLength);

    //    Debug.Log(didHit);
    //}
}