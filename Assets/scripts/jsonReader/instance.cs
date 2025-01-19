using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEditor;

public class instance : MonoBehaviour
{
	public string fileExtension = "obj";
	public instanceClasses myObject;
	public string[] json;
	private GameObject model;
	public string name;
	public List<GameObject> models;
	private selector selectorScript;
	private editSelection editSelectionScript;
	public string duplicate;

	void Start()
	{
		selectorScript = gameObject.GetComponent<selector>();
		editSelectionScript = GameObject.Find("Scripts").gameObject.GetComponent<editSelection>();
	}
	
	public void Load()
	{
		GameObject.Find("Canvas").transform.Find("name (TMP)").GetComponent<TMP_Text>().text = name + ".json";
		
		json = Directory.GetFiles("Assets/resources", name + ".json", SearchOption.AllDirectories);
		string contents = File.ReadAllText(json[0]);
		JsonUtility.FromJsonOverwrite(contents, myObject);
		
		foreach (instanceClass objects in myObject.objects)
		{
			Generate(objects);
		}
		SetModelsList();
	}
	
	public void Generate(instanceClass objects)
	{
		if (Resources.Load(name + "/" + objects.name))
		{
			model = Instantiate(Resources.Load(name + "/" + objects.name) as GameObject, new Vector3(
			float.Parse(objects.xPos), 
			float.Parse(objects.yPos), 
			float.Parse(objects.zPos)), Quaternion.Euler(
			float.Parse(objects.xRot), 
			float.Parse(objects.yRot),
			float.Parse(objects.zRot)));
			
			model.name = model.name.Replace("(Clone)","").Trim();
			model.AddComponent<reader>();
			foreach (Transform child in model.transform)
			{
				MeshCollider modelCollider = child.gameObject.AddComponent<MeshCollider>() as MeshCollider;
				child.gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Custom/Transparent/Diffuse Cutout");
				child.gameObject.AddComponent<selection>();
				models.Add(child.gameObject);
			}
			Debug.Log(model);
		}
	}
	
	public void DuplicateModel(GameObject selection)
	{
			model = Instantiate(Resources.Load(name + "/" + selection.name) as GameObject, new Vector3(
			selection.transform.position.x, 
			selection.transform.position.y, 
			selection.transform.position.z), Quaternion.Euler(
			selection.transform.rotation.x, 
			selection.transform.rotation.y, 
			selection.transform.rotation.z));
			
			model.name = model.name.Replace("(Clone)","").Trim();
			model.AddComponent<reader>();
			foreach (Transform child in model.transform)
			{
				MeshCollider modelCollider = child.gameObject.AddComponent<MeshCollider>() as MeshCollider;
				child.gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Custom/Transparent/Diffuse Cutout");
				child.gameObject.AddComponent<selection>();
				models.Add(child.gameObject);
			}
	}
	
	void SetModelsList()
	{
		selectorScript.models = models;
		editSelectionScript.models = models;
	}
}
