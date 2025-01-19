using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selection : MonoBehaviour
{
	public bool selected;
	
	public void Select()
	{
		selected = true;
	}
	
	public void Unselect()
	{
		selected = false;
	}
}
