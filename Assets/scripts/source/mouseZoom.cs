using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseZoom : MonoBehaviour
{
	public int scroll = -3;
	public float smoothSpeed = 16;
	
    void FixedUpdate()
    {
		gameObject.transform.localPosition = Vector3.Slerp(new Vector3(0, 0, transform.localPosition.z), new Vector3(transform.localPosition.x, transform.localPosition.y, scroll), smoothSpeed * Time.deltaTime);
	
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && scroll < 0 ) // forward
		{
		scroll += 1;
        }
		if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
		{
		scroll -= 1;
        }
    }
}
