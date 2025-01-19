using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleCamera : MonoBehaviour
{
	public mouseLook mouseLookScript;
	
    void Update()
    {
		transform.rotation = Quaternion.Euler(-mouseLookScript.Y/24, 0, 0);
    }
}
