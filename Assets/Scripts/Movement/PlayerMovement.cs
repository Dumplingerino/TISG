using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody player;
    public Transform cameraControl;

    public float movementSpeed = 100f;
    public float horizontalLookSpeed = 100f;

    private Vector3 movementDirection;

	// Use this for initialization
	void Start()
    {
        player = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update()
    {
        GetMovementDirection();
        MovePlayer();
        RotateCamera();
        RotatePlayer();
	}

    private void GetMovementDirection()
    {
        movementDirection = Input.GetAxis("Horizontal") * cameraControl.right
            + Input.GetAxis("Vertical") * cameraControl.forward;
    }

    private void MovePlayer()
    {
        player.velocity = Vector3.Normalize(movementDirection) * movementSpeed * Time.deltaTime;
    }

    private void RotatePlayer()
    {
        if (movementDirection != Vector3.zero)
        {
            player.MoveRotation(cameraControl.rotation);
            cameraControl.localRotation = Quaternion.Euler(Vector3.zero);
        }
    }

    private void RotateCamera()
    {
        cameraControl.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * horizontalLookSpeed, 0);
    }
}
