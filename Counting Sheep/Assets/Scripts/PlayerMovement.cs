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

    private void Update()
    {
        if (cameraController.getNarrative())
        {
            rotation.eulerAngles = new Vector3(0f, gameObject.transform.rotation.y * 180f, 0f);
            cameraObject.transform.position = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z + 0.5f);
            cameraObject.transform.rotation = rotation;
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

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
