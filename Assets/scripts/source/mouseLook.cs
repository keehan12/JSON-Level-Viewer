using UnityEngine;
 
 public class mouseLook : MonoBehaviour
 {
    private float X;
    private float Y;
    
    public float SensitivityX = 64;
	public float SensitivityY = 64;
	public float MIN_X = 0;
	public float MAX_X = 360;
	public float MIN_Y = 90;
	public float MAX_Y = -90;
	
    void Awake()
    {
        Vector3 euler = transform.rotation.eulerAngles;
    }
	
	void Start()
	{
		X += Input.GetAxis("Mouse X") * (SensitivityX * Time.deltaTime);
        Y -= Input.GetAxis("Mouse Y") * (SensitivityY * Time.deltaTime);
	}
     
    void FixedUpdate()
    {
	
        X += Input.GetAxis("Mouse X") * (SensitivityX * Time.deltaTime);
		if (X < MIN_X) X += MAX_X;
		else if (X > MAX_X) X -= MAX_X;
		Y -= Input.GetAxis("Mouse Y") * (SensitivityY * Time.deltaTime);
		if (Y < MIN_Y) Y = MIN_Y;
		else if (Y > MAX_Y) Y = MAX_Y;
		
		transform.rotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(Y, X, 0.0f), Time.deltaTime * 32);
	}
    }
