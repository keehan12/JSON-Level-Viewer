using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using TMPro;

public class writeJson : MonoBehaviour
{
	public List<GameObject> models;
	public string[] json;
	public writeClass writeObjectClass = new writeClass();
	public string filename;
	public string previousFilename;
	private messageBox messageBoxScript;
	private properties propertiesScript;
	
	void Start()
	{
		messageBoxScript = GameObject.Find("Scripts").GetComponent<messageBox>();
		propertiesScript = gameObject.GetComponent<properties>();
	}
	
	public void Read()
	{
		//Get Filenames
		previousFilename = GameObject.Find("Scripts").GetComponent<instance>().name;
		filename = GameObject.Find("Canvas").transform.Find("MessageBox").transform.Find("Filename (TMP_InputField)").GetComponent<TMP_InputField>().text;
		
		//Reset Models
		models.Clear();
		
		//Add Models
		foreach (reader model in FindObjectsOfType<reader>())
		{
			models.Add(model.gameObject);
		}
		
		if (filename != "Enter .json filename...")
		{
			Write();
		}
	}
	
	void Write()
	{
		//Copy Contents
		if (!System.IO.Directory.Exists("Assets/resources/"+filename))
        {
		Directory.CreateDirectory("Assets/resources/"+filename);
			foreach (string file in Directory.GetFiles("Assets/resources/"+previousFilename))
			{
				File.Copy(file, Path.Combine("Assets/resources/"+filename, Path.GetFileName(file)), true);
			}
		File.Delete("Assets/resources/"+filename+@"\"+previousFilename+".json");
		}
		
		//Reset JSON
		json = new string[models.Count];
		
		//Write JSON
		StreamWriter writer = new StreamWriter("Assets/resources/"+filename+"/"+filename+".json", false);
		writer.WriteLine("{");
		writer.WriteLine(@"""objects"":");
		writer.WriteLine("[");
		
		for(var i = 0; i < models.Count; i++)
		{
			//Write Class
			writeClass writeObjectClass = new writeClass();
			
			writeObjectClass.name = Convert.ToString(models[i].transform.name);
			writeObjectClass.xPos = Convert.ToString(models[i].transform.position.x);
			writeObjectClass.yPos = Convert.ToString(models[i].transform.position.y);
			writeObjectClass.zPos = Convert.ToString(models[i].transform.position.z);
			writeObjectClass.xRot = Convert.ToString(models[i].transform.rotation.eulerAngles.x);
			writeObjectClass.yRot = Convert.ToString(models[i].transform.rotation.eulerAngles.y);
			writeObjectClass.zRot = Convert.ToString(models[i].transform.rotation.eulerAngles.z);
			
			writer.WriteLine("{");
			writer.WriteLine(@"""name"": """ + writeObjectClass.name + @""",");
			writer.WriteLine(@"""xPos"": """ + writeObjectClass.xPos + @""",");
			writer.WriteLine(@"""yPos"": """ + writeObjectClass.yPos + @""",");
			writer.WriteLine(@"""zPos"": """ + writeObjectClass.zPos + @""",");
			writer.WriteLine(@"""xRot"": """ + writeObjectClass.xRot + @""",");
			writer.WriteLine(@"""yRot"": """ + writeObjectClass.yRot + @""",");
			writer.WriteLine(@"""zRot"": """ + writeObjectClass.zRot + @"""");
			
			if (i < models.Count-1)
			{
				writer.Write("}");
				writer.WriteLine(",");
			}
			if (i == models.Count-1)
			{
				writer.WriteLine("}");
			}
		}
		writer.WriteLine("]");
		writer.WriteLine("}");
		writer.Close();
		
		messageBoxScript.display = false;
		propertiesScript.overGui = false;
	}
}