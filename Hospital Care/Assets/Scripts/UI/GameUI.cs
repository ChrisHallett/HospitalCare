using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour 
{
	public static GameUI Instance;
	public bool DebugMode = false;

	public enum ModeEnum
	{
		Play,
		Build
	}

	[Header("Mode")]
	public ModeEnum Mode;

	[Header("Camera")]
	public RaycastHit MouseHit;
	public Ray MouseRay = new Ray();
	public LayerMask MouseLayer;

	// Use this for initialization
	void Start () 
	{
		//Setup Instance and don't destroy it
		if (Instance == null)
			Instance = this;
		else
			Destroy (gameObject);

		//Defaults
		MouseLayer = 256;
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetMouseGridCoordinates ();
	}

	void SetMode(int mode)
	{
		if (mode == 0)
		{
			Mode = ModeEnum.Play;
			BuildMode.Instance.enabled = false;
		}
		else if (mode == 1)
		{
			Mode = ModeEnum.Build;
			BuildMode.Instance.enabled = true;
		}
	}

	/// <summary>
	/// Raycasts on desired Layer and return hit GameObject.
	/// </summary>
	/// <returns>The hit object.</returns>
	/// <param name="Layer">Layer</param>
	public GameObject RaycastMouseObject(LayerMask Layer)
	{
		if (Camera.main == null)
			return null;

		MouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		//We hit ray things in the Terrain Layer
		if (Physics.Raycast (MouseRay, out MouseHit, 256, Layer.value))
		{
			if(DebugMode)
				Debug.DrawLine (MouseRay.origin, MouseHit.point, Color.cyan);
			
			return MouseHit.collider.gameObject;
		}
		return null;
	}

	public Vector3Int GetMouseGridCoordinates()
	{
		if (Camera.main == null)
		{
			print ("Error: No Camera.main present");
			return Vector3Int.zero;
		}

		MouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		//We hit ray things in the Terrain Layer
		if (Physics.Raycast (MouseRay, out MouseHit, 1024, MouseLayer.value))
		{
			if(DebugMode)
				Debug.DrawLine (MouseRay.origin, MouseHit.point, Color.cyan);
			return new Vector3Int(Mathf.RoundToInt(MouseHit.point.x),Mathf.RoundToInt(MouseHit.point.y),Mathf.RoundToInt(MouseHit.point.z));
		}
		return Vector3Int.zero;
	}
}
