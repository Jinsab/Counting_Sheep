using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
			public GameObject target;
			[SerializeField] private bool autoVelociter;
			private NavMeshAgent agent;
			private new Rigidbody rigidbody;
    
			private void Awake()
			{
						agent = GetComponent<NavMeshAgent>();
						rigidbody = GetComponent<Rigidbody>();
			}

			void Start()
			{
						if (autoVelociter)
						{
									StartCoroutine("VelocityZero");
						}
			}

			void FixedUpdate()
			{
						if (!agent.pathPending)
						{
									agent.destination = target.transform.position;
						}
			}

			IEnumerable VelocityZero()
			{
						rigidbody.velocity = rigidbody.velocity = Vector3.zero;

						yield return new WaitForSeconds(1f);

						StartCoroutine("VelocityZero");
			}
}