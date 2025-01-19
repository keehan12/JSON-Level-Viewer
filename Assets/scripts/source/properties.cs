using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class properties : MonoBehaviour
{
	public bool showCursor = true;
	public bool overGui;
	private bool fullscreen;
	public Texture cursor;
	public int cursorSize = 16;
	private float screenWidthLast;
	private float screenHeightLast;
	private float screenWidth;
	private float screenHeight;
	
	void Start ()
	{   
		fullscreen = Convert.ToBoolean(PlayerPrefs.GetInt("fullscreen"));
		ShowCursor();
		Fullscreen();
	}	
	
	void OnGUI()
	{
		if (showCursor == false)
		{
			GUI.DrawTexture (new Rect ((Screen.width / 2) - (cursorSize/2), (Screen.height / 2) - (cursorSize/2), cursorSize, cursorSize), cursor);
		}
	}
	
    void Update ()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			if (GameObject.Find("Canvas").transform.Find("MessageBox").gameObject.activeSelf == false)
			{
				fullscreen = !fullscreen;
				PlayerPrefs.SetInt("fullscreen", Convert.ToInt32(fullscreen));
				Fullscreen();
			}
		}
		
		if (Input.GetKeyDown(KeyCode.R))
		{
			if (GameObject.Find("Canvas").transform.Find("MessageBox").gameObject.activeSelf == false)
			{
				SceneManager.LoadScene(0);
			}
		}
		
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (showCursor == true)
			{
				if (GameObject.Find("Canvas").transform.Find("MessageBox").gameObject.activeSelf == false)
				{
					Quit();
				}
			}
			
			if (showCursor == false)
			{
			showCursor = true;
			ShowCursor();
			}
		}
		
		if (Input.GetMouseButtonDown(0) && !GameObject.Find("Canvas").transform.Find("jsonPicker") && GameObject.Find("Canvas").transform.Find("MessageBox").gameObject.activeSelf == false)
		{
				if (overGui == false)
				{
					if (showCursor == true)
					{
					showCursor = false;
					ShowCursor();
					}
				}
		}
	}

	public void ShowCursor()
	{	
		if (showCursor == false)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		
		if (showCursor == true)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
	
	void Quit()
	{
		Debug.Log("Quit");
		Application.Quit();
	}
	
	void Fullscreen()
	{
		if (fullscreen == true)
		{
			Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, true);
		}
		
		if (fullscreen == false)
		{
			Screen.SetResolution(960, 540, false);
		}
	}
	
	public void overGuiTrue()
	{
		overGui = true;
	}
	
	public void overGuiFalse()
	{
		overGui = false;
	}
}
