using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] private int m_Resource;
    [SerializeField] private int m_Energy;
    public Text ResourceText;
    public Text EnergyText;

    public int Resource
    {
        get
        {
            return m_Resource;
        }

        set
        {
            m_Resource = value;
            ResourceText.text = "" + m_Resource;
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
            m_Energy = value;
            EnergyText.text = "" + m_Energy;
        }
    }

    private void Awake()
    {
        Resource = 0;
        Energy = 0;
    }
}