using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildMode : MonoBehaviour 
{
	public static BuildMode Instance;
	public enum ConstructionEnum
	{
		Wall,
		Floor,
		Object
	}
	public ConstructionEnum ConstructionMode;
	private GameObject GhostObject;	//Used to visually show our object we want to place

	// Use this for initialization
	void Start () 
	{
		if (Instance == null)
			Instance = this;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
