using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour 
{
	public GameObject MainCamera;	//The Scene Camera

	[Tooltip("Does the camera move when the mouse hits the edge of the screen?")]
	public bool EdgeScrolling = true;

	public float Speed = 5;	//How fast does the camera move through WASD
	public float SpeedBoost = 10;	//How fast when boosting
	public float RotateSpeed = 120;	//Rotation Speed

	public float ZoomMax = 10;	//How far away can we zoom?
	public float ZoomMin = 2;	//How close can we zoom?
	public float ZoomSpeed = 200;	//How  fast do we zoom?

	public Vector3 Norm;	//Used for updates
	private Vector3 NewPos;
	private bool MouseOverGui = false;	//if true we can't edge scroll

	// Use this for initialization
	void Start () 
	{
		
	}

	// Update is called once per frame
	void Update () 
	{
		
	}

	void FixedUpdate()
	{
		//WASD
		Norm.x += Input.GetAxis ("Horizontal");
		Norm.y = 0;
		Norm.z += Input.GetAxis ("Vertical") ;

		//Mouse
		if (EdgeScrolling)
		{
			if (Input.mousePosition.x >= Screen.width * 0.99f && MouseOverGui == false)
				Norm.x = 1;
			else if (Input.mousePosition.x <= Screen.width * 0.01f && MouseOverGui == false)
				Norm.x = -1;
		
			if (Input.mousePosition.y >= Screen.height * 0.99f && MouseOverGui == false)
				Norm.z = 1;
			else if (Input.mousePosition.y <= Screen.height * 0.01f && MouseOverGui == false)
				Norm.z = -1;
		}

		Norm *= Time.deltaTime;

		if(Input.GetButton("Speed"))
			transform.Translate (Norm.x * SpeedBoost, Norm.y * SpeedBoost, Norm.z * SpeedBoost);
		else
			transform.Translate (Norm.x * Speed, Norm.y * Speed, Norm.z * Speed);

		NewPos = transform.position;
		if (transform.position.x <= -0.5f)
		{
			NewPos.x = -0.5f;
		}
		else if (transform.position.x >= GameManager.Instance.MapSizeX  - 0.5f)
		{
			NewPos.x = GameManager.Instance.MapSizeX - 0.5f;
		}
		if (transform.position.z <= -0.5f)
		{
			NewPos.z = -0.5f;
		}
		else if (transform.position.z >= GameManager.Instance.MapSizeZ - 0.5f)
		{
			NewPos.z = GameManager.Instance.MapSizeZ - 0.5f;
		}

		//Finish with our Position Math, now apply it
		transform.position = NewPos;

		//Max and Min Zoom TODO Fix this

		if (MainCamera.transform.position.y > ZoomMin && Input.GetAxis ("Zoom") > 0)
		{
			MainCamera.transform.Translate (((Vector3.forward * Input.GetAxis ("Zoom")) * ZoomSpeed) * Time.deltaTime);
			//OrthoCamera.GetComponent<Camera> ().orthographicSize -= 10 * Time.deltaTime;
			//Speed -= 10 * Time.deltaTime;
		}
		else if (MainCamera.transform.position.y < ZoomMax  && Input.GetAxis ("Zoom") < 0)
		{
			MainCamera.transform.Translate (((Vector3.forward * Input.GetAxis ("Zoom")) * ZoomSpeed) * Time.deltaTime);	
			//OrthoCamera.GetComponent<Camera> ().orthographicSize += 10 * Time.deltaTime;
			//Speed += 10 * Time.deltaTime;
		}


		//Camera Rotation
		if (Input.GetAxis ("Rotate") != 0)
			transform.Rotate (0, Input.GetAxis ("Rotate") * RotateSpeed * Time.deltaTime, 0);
	}
}