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
            /*
            mPosition.z = oPosition.z - Camera.main.transform.position.z;

            Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);

            float dy = target.y - oPosition.y;
            float dx = target.x - oPosition.x;

            float rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, rotateDegree, 0f);
            */

            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
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
