using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
	public GameObject Door1;
	public GameObject Door2;
	public ResourceManager resource;
	[SerializeField] private int OpenPoint = 0;
	private int i = 1;

    private void Update()
    {
		if (OpenPoint < resource.Resource)
		{
			if (Door1.transform.rotation.eulerAngles.y > -120f && Door2.transform.rotation.eulerAngles.y < 120f)
			{
				Door1.transform.rotation = Quaternion.Euler(new Vector3(0f, -i, 0f));
				Door2.transform.rotation = Quaternion.Euler(new Vector3(0f, i, 0f));			
			}
			else
			{
				gameObject.SetActive(false);
			}

			i++;
		}
    }
}
