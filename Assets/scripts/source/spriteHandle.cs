using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteHandle : MonoBehaviour
{
private Camera camera;
private float X;
private float Y;
	
	void Update () 
	{
		if (camera == null)
		{
			camera = GameObject.Find("Canvas (3D)").transform.Find("HandleCamera").transform.Find("Camera").gameObject.GetComponent<Camera>();
		}
		if (camera != null)
		{
			X = camera.transform.rotation.eulerAngles.x;
			Y = camera.transform.rotation.eulerAngles.y;
			transform.rotation =  Quaternion.Euler(X, Y, transform.rotation.eulerAngles.z);
		}
	}
}
