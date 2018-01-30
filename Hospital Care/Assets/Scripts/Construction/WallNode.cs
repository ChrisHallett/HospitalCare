using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallNode : MonoBehaviour 
{
	//Are we making a wall to connection?
	public bool N_Connect = false;
	public bool E_Connect = false;
	public bool W_Connect = false;
	public bool S_Connect = false;

	public GameObject N_Wall;
	public GameObject E_Wall;
	public GameObject W_Wall;
	public GameObject S_Wall;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
