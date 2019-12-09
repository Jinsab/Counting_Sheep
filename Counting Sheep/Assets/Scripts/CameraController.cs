using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float maxZome = 20f;
	public float minZome = 60f;
	public float speed = 10.0f;
	public Transform cameraTarget;

	private Camera thisCamera;
	private Vector3 worldDefalutForward;
	private bool subCamera = true;

	private void Start()
	{
		thisCamera = GetComponent<Camera>();
		worldDefalutForward = transform.forward;
	}

	private void Update()
	{
		float scroll = Input.GetAxis("Mouse ScrollWheel") * speed;

								
		if (thisCamera.fieldOfView <= maxZome && scroll < 0)			 //최대 줌인
		{
			thisCamera.fieldOfView = maxZome;
		}		
		else if (thisCamera.fieldOfView >= minZome && scroll > 0)		// 최대 줌 아웃
		{
			thisCamera.fieldOfView = minZome;
		}
		else		// 줌인 아웃 하기.
		{
			thisCamera.fieldOfView += scroll;
		}
						
		/*
		// 일정 구간 줌으로 들어가면 캐릭터를 바라보도록 한다.
		if (cameraTarget && thisCamera.fieldOfView <= 30.0f)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(cameraTarget.position - transform.position), 0.15f);
		}
		// 일정 구간 밖에서는 원래의 카메라 방향으로 되돌아 가기.
		else
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(worldDefalutForward), 0.15f);
		}
		*/

		//thisCamera.transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.x + 20f, cameraTarget.position.z);

		if (Input.GetKeyDown(KeyCode.F))
		{
			if (subCamera)
			{
				subCamera = false;
			}
			else
			{
					subCamera = true;
			}
		}
	}

	public bool getNarrative()
	{
		return subCamera;
	}
}