using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody player;
    public Transform cameraControl;
    public Transform cameraYaw;
    public Transform cameraObject;

    public float movementSpeed = 300f;
    public float runSpeed = 300f;
    public float horizontalLookSpeed = 100f;
    public float verticalLookSpeed = 100f;

    private Vector3 movementDirection;
    

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update()
    {
        FollowPlayer(cameraControl);
        GetMovementDirection();
        RotateCamera();
        RotatePlayer();
        MovePlayer();
        CameraDistance(4);
	}

    private void GetMovementDirection()
    {
        movementDirection = Input.GetAxis("Horizontal") * cameraControl.right
            + Input.GetAxis("Vertical") * cameraControl.forward;
    }

    private void MovePlayer()
    {
        player.velocity = Vector3.Normalize(movementDirection) * Time.deltaTime * 
            (movementSpeed * (1 - Input.GetAxis("Run")) + runSpeed * Input.GetAxis("Run"));
    }

    private void RotatePlayer()
    {
        if (movementDirection != Vector3.zero)
        {
            player.MoveRotation(cameraControl.rotation);
        }
    }

    private void RotateCamera()
    {
        cameraControl.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * horizontalLookSpeed, 0);
        cameraYaw.Rotate(-1 * Input.GetAxis("Mouse Y") * Time.deltaTime * verticalLookSpeed, 0, 0);
        ClampCameraRotation(-50, 80);
    }

    private void ClampCameraRotation(float min, float max)
    {
        float x = cameraYaw.rotation.eulerAngles.x;
        if (x > 180)
        {
            x -= 360;
        }
        x = Mathf.Min(max, Mathf.Max(min, x));
        cameraYaw.localRotation = Quaternion.Euler(x, 0, 0);
    }

    private void CameraDistance(float distance)
    {
        RaycastHit hit;

        if (Physics.Raycast(cameraYaw.position, -cameraYaw.forward, out hit))
        {
            if (hit.distance > distance)
            {
                cameraObject.localPosition = new Vector3(0, 0, -distance);
            } else
            {
                cameraObject.localPosition= new Vector3(0, 0, -hit.distance + 0.1f);
            }
        }
    }

    private void FollowPlayer(Transform follower)
    {
        follower.position = player.position;
    }
}
