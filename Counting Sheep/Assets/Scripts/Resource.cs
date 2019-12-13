using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Resource : MonoBehaviour
{
	public int totalResources = 100;          // 총 자원량
	public int gatheringResources = 5;        // 자원 채취량
	[SerializeField] private float rate = 1f;  // 자원 캐는 속도
	[SerializeField] private ResourceManager player_Resource;
	private float time = 0f;

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			time += Time.deltaTime;

			if (time > rate)
			{
				player_Resource.Resource += GetResource();
				time = 0f;
			}

			if (totalResources == 0)
			{
				gameObject.SetActive(false);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			time = 0f;
		}
	}

	private int GetResource()
	{
		totalResources -= gatheringResources;
		Debug.Log("Total Resource : " + totalResources);
		return gatheringResources;
	}
}
