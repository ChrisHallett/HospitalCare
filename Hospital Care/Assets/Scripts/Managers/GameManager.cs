using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public static GameManager Instance;

	[Tooltip("Map X size in units.")]
	public int MapSizeX;
	[Tooltip("Map Z size in units.")]
	public int MapSizeZ;

	[Tooltip("Maximum number of floors, 0 is ground floor.")]
	public int MapSizeFloors;

	public Transform BorderObject;
	//For Visual debug
	public Transform GroundObject;

	public FloorType[] Floors;

	// Use this for initialization
	void Start () 
	{
		//Setup Instance and don't destroy it
		if (Instance == null)
			Instance = this;
		else
			Destroy (gameObject);

		GenerateBorder ();
		GenerateMap ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Generate an empty map, TODO replace with level presets.
	void GenerateMap()
	{
		Floors = new FloorType[MapSizeFloors];

		for (int i = 0; i < Floors.Length; i++)
		{
			Floors [i].Tiles = new TileType[MapSizeX,MapSizeZ];
			Floors [i].Walls = new WallNode[MapSizeX + 1,MapSizeZ + 1];
			Floors [i].Floor = i;
		}
	}

	void GenerateBorder()
	{
		BorderObject.localScale = new Vector3(MapSizeX + 2, MapSizeZ + 2, 1);
		BorderObject.position = new Vector3 (MapSizeX / 2, -0.1f,  MapSizeZ / 2);

		//Debug/TODO Temp till proper theme and ground gen code
		GroundObject.localScale = new Vector3(MapSizeX, MapSizeZ, 1);
		GroundObject.position = new Vector3 (MapSizeX / 2, -0.01f,  MapSizeZ / 2);
		GroundObject.GetComponent<MeshRenderer> ().material.mainTextureScale = new Vector2 (MapSizeX,MapSizeZ);
	}
}
