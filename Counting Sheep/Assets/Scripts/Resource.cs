using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public int totalResources = 100;          // 총 자원량
    public int gatheringResources = 5;        // 자원 채취량
    [SerializeField] private float rate = 1;  // 자원 캐는 속도
    private float time;

    private void Start()
    {
        time = Time.time;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {

        }

        GetResource();
    }

    private int GetResource()
    {
        return gatheringResources;
    }

    
}
