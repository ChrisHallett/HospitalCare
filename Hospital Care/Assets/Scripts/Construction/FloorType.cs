using UnityEngine;

[System.Serializable]
public class FloorType 
{
	public int Floor = 0;
	public TileType[,] Tiles;
	public WallNode[,] Walls;
}
