using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileType 
{
	//XZ Plane
	public int X;
	public int Z;
	//What Floor
	public int Y;

	//Is there something blocking this tile?
	public bool IsOccupied = false;

	//The object that's occupying this tile
	public GameObject OccupiedObject;
}
