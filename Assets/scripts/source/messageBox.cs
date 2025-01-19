using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messageBox : MonoBehaviour
{
	public bool display;
	private properties propertiesScript;
	
	void Start()
	{
		propertiesScript = GameObject.Find("Scripts").GetComponent<properties>();
	}
	
	void Update()
	{
		//Display Message Box
		if (Input.GetKeyDown(KeyCode.J))
		{
			if (GameObject.Find("Canvas").transform.Find("MessageBox").gameObject.activeSelf == false)
			{
				display = true;
			}
		}
		
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (display == true)
			{
				display = false;
				propertiesScript.overGui = false;
			}
		}
		
		if (display == false && GameObject.Find("Canvas").transform.Find("MessageBox").gameObject.activeSelf == true)
		{
			GameObject.Find("Canvas").transform.Find("MessageBox").gameObject.SetActive(false);
		}
		if (display == true && GameObject.Find("Canvas").transform.Find("MessageBox").gameObject.activeSelf == false)
		{
			GameObject.Find("Canvas").transform.Find("MessageBox").gameObject.SetActive(true);
			propertiesScript.showCursor = true;
			propertiesScript.ShowCursor();
		}
	}
}
