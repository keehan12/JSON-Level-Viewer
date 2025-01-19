using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class selector : MonoBehaviour
{
	public LayerMask layerMask;
	public List<GameObject> models;
	private editSelection editSelectionScript;
	private properties propertiesScript;
	
	void Start()
	{
		editSelectionScript = gameObject.GetComponent<editSelection>();	
		propertiesScript = gameObject.GetComponent<properties>();
	}
	
    void Update()
	{
		if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
		{
			//Select
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
			{
				if (editSelectionScript.selection != null)
				{
					Unselect();
				}
				
				if (hit.transform.parent.gameObject == editSelectionScript.selection)
				{
					editSelectionScript.selection = null;
					hit.transform.gameObject.GetComponent<selection>().Unselect();
				}
				else
				{
					if (propertiesScript.overGui == false)
					{
						editSelectionScript.selection = hit.transform.parent.gameObject;
						hit.transform.gameObject.GetComponent<selection>().Select();
					}
				}
			}
			else
			{
				if (editSelectionScript.selection != null)
				{
					Unselect();
				}
				editSelectionScript.selection = null;
			}
		}
	}
	
	void Unselect()
	{
		//Unselect
		foreach (GameObject model in models)
		{
			if (model.GetComponent<selection>().selected == true)
			{
				model.GetComponent<selection>().Unselect();
			}
		}
	}
}
