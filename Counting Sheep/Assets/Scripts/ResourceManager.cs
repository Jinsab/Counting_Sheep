using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private int m_Resource;
    private int m_Energy;

    public int Resource
    {
        get
        {
            return m_Resource;
        }

        set
        {
            m_Resource = Resource;
        }
    }

    public int Energy
    {
        get
        {
            return m_Energy;
        }

        set
        {
            m_Energy = Energy;
        }
    }

    private void Awake()
    {
        Resource = 0;
        Energy = 0;
    }
}
