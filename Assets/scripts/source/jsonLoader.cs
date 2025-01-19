using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;

public class jsonLoader : MonoBehaviour
{
    public string folderPath;
    public string[]  filePaths;
	public List<string> fileList;
	public GameObject jsonObject;
	public GameObject json;
	public List<GameObject> jsonObjects;
	
    void Awake()
    {
		//Get Files
		folderPath = "Assets/resources";  //Get path of folder
		filePaths = Directory.GetFiles(folderPath, "*.json", SearchOption.AllDirectories);
	}
	
	void Start()
    {
		for (int i = 0; i < filePaths.Length; i++)
		{
			filePaths[i] = Path.GetFileNameWithoutExtension(filePaths[i]);
		}
		
		//Add to List
		foreach(string file in filePaths)
		{
			fileList.Add(file);	
		}
	
		for (int i = 0; i <= fileList.Count; i++)
		{
			if (i < fileList.Count)
			{
				jsonObject = Instantiate(json);
				jsonObject.transform.SetParent(GameObject.Find("Canvas").transform.Find("jsonPicker").transform);
				jsonObject.transform.position = GameObject.Find("Canvas").transform.Find("jsonPicker").transform.position;
				jsonObject.transform.localPosition = new Vector3(0, (i*jsonObject.GetComponent<RectTransform>().sizeDelta.y)+(jsonObject.GetComponent<RectTransform>().sizeDelta.y/2), 0);
				jsonObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
				jsonObject.GetComponent<jsonPicker>().json = fileList[i];
				
				var jsonObjectText = jsonObject.transform.GetComponent<TMP_Text>();
				jsonObjectText.text = fileList[i];
				
				jsonObjects.Add(jsonObject);
			}
			if (i == fileList.Count)
			{
				GameObject.Find("Canvas").transform.Find("jsonPicker").transform.localPosition = new Vector3(0, i*-(jsonObject.GetComponent<RectTransform>().sizeDelta.y/2), 0);
			}
		}
	}
}
