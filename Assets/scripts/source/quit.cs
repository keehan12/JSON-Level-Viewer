using UnityEngine;

public class quit : MonoBehaviour
{
	void Update ()
	{	
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
