using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class editSelection : MonoBehaviour
{
	public GameObject selection;
	private bool leftShift;
	private bool once;
	private instance instanceScript;
	private bool doubleSided;
	public List<GameObject> models;

	void Start()
    {
        instanceScript = GameObject.Find("Scripts").gameObject.GetComponent<instance>();	
    }
	
    void Update()
    {
		//Key Coordinations
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			leftShift = true;
		}
		
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			leftShift = false;
		}
		
		//Move
		if (selection != null)
		{
			if (Input.GetAxis("HorizontalArrowKeys") != 0 || Input.GetAxis("VerticalArrowKeys") != 0)
			{
				if (once == false)
				{
					if (leftShift == false)
					{
						selection.transform.position += new Vector3(Input.GetAxis("HorizontalArrowKeys"), 0, Input.GetAxis("VerticalArrowKeys"));
					}
					
					if (leftShift == true)
					{
						selection.transform.position += new Vector3(Input.GetAxis("HorizontalArrowKeys"), Input.GetAxis("VerticalArrowKeys"), 0);
					}
					once = true;
				}
			}
			if (Input.GetAxis("HorizontalArrowKeys") == 0 && Input.GetAxis("VerticalArrowKeys") == 0 && once == true)
			{
				once = false;
			}
		}
		
		//Duplicate
		if(Input.GetKeyDown(KeyCode.C) && selection != null)
		{
			instanceScript.duplicate = selection.transform.name;
			instanceScript.DuplicateModel(selection);
		}
		
		//Double Sided Material Shader
		if (Input.GetKeyDown(KeyCode.K))
		{
			if (GameObject.Find("Canvas").transform.Find("MessageBox").gameObject.activeSelf == false)
			{
				doubleSided = !doubleSided;
				DoubleSided();
			}
		}
    }
	
	void DoubleSided()
	{
		foreach (GameObject model in models)
		{
			Material[] materials = model.gameObject.GetComponent<Renderer>().materials;
			
			if (doubleSided == false)
			{
				foreach (Material material in materials)
				{
					material.shader = Shader.Find("Custom/Transparent/Diffuse Cutout");
				}
			}
			
			if (doubleSided == true)
			{
				foreach (Material material in materials)
				{
					material.shader = Shader.Find("Custom/Transparent/Diffuse Cutout_DoubleSided");
				}
			}
		}	
	}
}
