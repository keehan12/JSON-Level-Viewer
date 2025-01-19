using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class jsonPicker : MonoBehaviour
{
    private properties propertiesScript;
	public string json = "default";
	private instance instanceScript;
	
    void Start()
    {
        propertiesScript = GameObject.Find("Scripts").GetComponent<properties>();
		this.GetComponent<TMP_Text>().text = json + ".json";
		instanceScript = GameObject.Find("Scripts").GetComponent<instance>();
    }
	
	public void ClickedOn()
	{
		propertiesScript.overGui = false;
		
		instanceScript.name = json;
		instanceScript.Load();
		
		Destroy(GameObject.Find("Canvas").transform.Find("jsonPicker").gameObject);
	}
	
	public void overGuiTrue()
	{
		propertiesScript.overGui = true;
	}
	
	public void overGuiFalse()
	{
		propertiesScript.overGui = false;
	}
}
