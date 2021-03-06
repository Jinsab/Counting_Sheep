﻿using System.Collections;
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
	private new Rigidbody rigidbody;
	private Animator animator;

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
	}

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
			cameraObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 20f, gameObject.transform.position.z);
			cameraObject.transform.rotation = rotation;
		}
	}

	private void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		movement = transform.TransformDirection(movement);
		Debug.Log(transform.TransformDirection(movement));

		if (Input.GetKey(KeyCode.LeftShift))
		{
			// transform.Translate(movement * (speed * 1.5f) * Time.deltaTime);
			rigidbody.AddForce(movement * (speed * 1.5f));
			animator.SetInteger("animation", 3);
		}
		else if (movement != new Vector3(0f, 0f, 0f))
		{
			//transform.Translate(movement * speed * Time.deltaTime);
			rigidbody.AddForce(movement * speed);
			animator.SetInteger("animation", 2);
		}
		else
		{
			animator.SetInteger("animation", 0);
		}

		//rigidbody.velocity = Vector3.zero;
	}
}
