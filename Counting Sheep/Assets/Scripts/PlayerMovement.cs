using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public CameraController cameraController;
    public GameObject cameraObject;
    public GameObject SubCameraObject;

    private Quaternion rotation = Quaternion.identity;
    private bool isJump = false;

    private void Update()
    {
        if (cameraController.getNarrative())
        {
            cameraObject.transform.position = SubCameraObject.transform.position;
            cameraObject.transform.rotation = new Quaternion(0f, gameObject.transform.rotation.y, 0f, gameObject.transform.rotation.w);
        }   
        else
        {
            rotation.eulerAngles = new Vector3(90f, 0f, 0f);
            cameraObject.transform.position = new Vector3(transform.position.x, transform.position.y + 20f, transform.position.z);
            cameraObject.transform.rotation = rotation;
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(movement * (speed * 1.5f) * Time.deltaTime);
        }
        else
        {
            transform.Translate(movement * speed * Time.deltaTime);
        }
    }
}
