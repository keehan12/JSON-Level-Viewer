using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class flyCamera : MonoBehaviour
{
	public float climbSpeed = 4;
	public float normalMoveSpeed = 10;
	public bool holdingCtrlKey;
	
	private properties propertiesScript;
	
	void Start()
	{
		propertiesScript = GameObject.Find("Scripts").GetComponent<properties>();
	}
	
    void FixedUpdate ()
	{
		if (propertiesScript.showCursor == false)
		{
			if (Input.GetMouseButton(1) || Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.Q)|| Input.GetKey (KeyCode.E))
			{
			transform.position += transform.forward * normalMoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
			transform.position += transform.right * normalMoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
					
				if (Input.GetKey (KeyCode.E))
				{
					transform.position += transform.up * (climbSpeed) * Time.deltaTime;
				}
				if (Input.GetKey (KeyCode.Q))
				{
					transform.position -= transform.up * (climbSpeed) * Time.deltaTime;
				}
			}
		}
    }
}