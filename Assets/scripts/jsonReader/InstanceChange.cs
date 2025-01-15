using UnityEngine;

public class InstanceChange : MonoBehaviour
{
	public ClassesChange myObject;
	public TextAsset json;
	private GameObject model;
	
	void Awake()
	{
		JsonUtility.FromJsonOverwrite(json.text, myObject);
	}
	
	void Start()
	{
		Generate();
	}
	
	void Generate()
	{
		foreach (MyClassChange objects in myObject.objects)
		{
			if (Resources.Load(objects.name))
			{
				model = Instantiate(Resources.Load(objects.name) as GameObject, new Vector3(
				float.Parse(objects.xPos), 
				float.Parse(objects.yPos), 
				float.Parse(objects.zPos)), Quaternion.Euler(
				float.Parse(objects.xRot), 
				float.Parse(objects.yRot), 
				float.Parse(objects.zRot)));
			}
		}
	}
}
