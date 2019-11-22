using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public int totalResources = 100;          // 총 자원량
    public int gatheringResources = 5;        // 자원 캐는 량
    [SerializeField] private float rate = 1;  // 자원 캐는 속도
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GetResource();
    }

    private int GetResource()
    {
        return gatheringResources;
    }
}
