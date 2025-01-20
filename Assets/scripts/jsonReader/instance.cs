using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEditor;

public class instance : MonoBehaviour
{
	public instanceClasses myObject;
	public string[] json;
	private GameObject model;
	public string name;
	public List<GameObject> models;
	private selector selectorScript;
	private editSelection editSelectionScript;
	public string duplicate;
	
	public Vector3 offsetAngle;

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
			float.Parse(objects.xRot) + offsetAngle.x, 
			float.Parse(objects.yRot) + offsetAngle.y,
			float.Parse(objects.zRot) + offsetAngle.z));
			
			model.name = model.name.Replace("(Clone)","").Trim();
			model.AddComponent<reader>();
			
			Transform modelChild = model.transform.GetChild(0);
			
			for(var i = 0; i < modelChild.transform.childCount + i; i++)
			{
				modelChild.GetChild(0).SetParent(model.transform);
			}
			
			foreach (Transform child in model.transform)
			{
				if (child.GetComponent<Renderer>())
				{
					Material[] materials = child.gameObject.GetComponent<Renderer>().materials;
					foreach (Material material in materials)
					{
						//material.shader = Shader.Find("Custom/Transparent/Diffuse Cutout");
					}
				}
				MeshCollider modelCollider = child.gameObject.AddComponent<MeshCollider>() as MeshCollider;
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
		selection.transform.rotation.x + offsetAngle.x, 
		selection.transform.rotation.y + offsetAngle.y, 
		selection.transform.rotation.z + offsetAngle.z));
		
		model.name = model.name.Replace("(Clone)","").Trim();
		model.AddComponent<reader>();
		
		Transform modelChild = model.transform.GetChild(0);
		
		for(var i = 0; i < modelChild.transform.childCount + i; i++)
		{
			modelChild.GetChild(0).SetParent(model.transform);
		}
		
		foreach (Transform child in model.transform)
		{
			if (child.GetComponent<Renderer>())
			{
				Material[] materials = child.gameObject.GetComponent<Renderer>().materials;
				foreach (Material material in materials)
				{
					//material.shader = Shader.Find("Custom/Transparent/Diffuse Cutout");
				}
			}
			MeshCollider modelCollider = child.gameObject.AddComponent<MeshCollider>() as MeshCollider;
			child.gameObject.AddComponent<selection>();
			child.GetComponent<selection>().Select();
			models.Add(child.gameObject);
		}
		editSelectionScript.selection = model;
		Debug.Log(model);
	}
	
	void SetModelsList()
	{
		selectorScript.models = models;
		editSelectionScript.models = models;
	}
}
