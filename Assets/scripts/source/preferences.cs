using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class preferences : MonoBehaviour
{
    public int graphics;
	private int maxGraphics = 3;
	private Light directionalLight;
	private Slider fogDistanceSlider;

	void Start()
	{
		directionalLight = GameObject.Find("Directional Light").GetComponent<Light>();
		fogDistanceSlider = GameObject.Find("Canvas").transform.Find("FogDistance (Slider)").GetComponent<Slider>();
		
		ApplyGraphics();
	}
	
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
		{
			graphics += 1;
			
			if (graphics >= maxGraphics)
			{
				graphics = 0;
			}
			
			ApplyGraphics();
		}
    }
	
	void ApplyGraphics()
	{
		//graphics mode 0
		if (graphics == 0)
		{
			ChangeColors();
			RenderSettings.fog = false;
			directionalLight.gameObject.SetActive(false);
		}
		
		//graphics mode 1
		if (graphics == 1)
		{
			ChangeColors();
			directionalLight.gameObject.SetActive(true);
		}
		//graphics mode 2
		if (graphics == 2)
		{
			ChangeColors();
			RenderSettings.fog = true;
			directionalLight.gameObject.SetActive(true);
		}
	}
	
	public void OnFogDistanceChanged()
	{
		RenderSettings.fogStartDistance = fogDistanceSlider.value*4;
		RenderSettings.fogEndDistance = fogDistanceSlider.value*12f;
	}
	
	void ChangeColors()
	{
		RenderSettings.fogColor = new Color(0, 0, 0);
		RenderSettings.fogStartDistance = fogDistanceSlider.value*4;
		RenderSettings.fogEndDistance = fogDistanceSlider.value*12f;
		RenderSettings.ambientLight = new Color(0.7f, 0.5f, 0.6f);
		RenderSettings.ambientIntensity = 10f;
		
		//Override ChangeColors
		if (graphics == 0)
		{
			RenderSettings.ambientLight = new Color(1, 1, 1);
		}
	}
}
