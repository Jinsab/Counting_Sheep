using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    public CameraController cameraController;
    private enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    private RotationAxes axes = RotationAxes.MouseX;
    private float sensitivityX = 15f;
    private float sensitivityY = 15f;
    private float minimumX = -360f;
    private float maximumX = 360f;
    private float minimumY = -360f;
    private float maximumY = 360f;
    private float rotationY = 0f;

    void Update()
    {
        Vector3 mPosition = Input.mousePosition;
        Vector3 oPosition = transform.position;

        if (cameraController.getNarrative()) { // 1인칭 시점
            transform.Rotate(0f, Input.GetAxis("Mouse X") * sensitivityX, 0f);
        }
        else { // 3인칭 시점
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);

            float rayLength;

            if (GroupPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointTolook = cameraRay.GetPoint(rayLength);

                transform.LookAt(new Vector3(pointTolook.x, transform.position.y, pointTolook.z));
            }
        }
    }
}
