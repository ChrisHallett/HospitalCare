using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    private GridManager gridObject;

    [SerializeField]
    private int buildingSize = 10;
    private GameObject floorPrefab;
    private GameObject wallPrefab;

    // Use this for initialization
    void Start ()
    {
        gridObject = FindObjectOfType<GridManager>();
        if (gridObject == null)
        {
            Debug.LogError("Could not find grid manager, please ");
        }

        floorPrefab = Resources.Load<GameObject>(Constants.PrefabsPath + "FloorPrefab");
        wallPrefab = Resources.Load<GameObject>(Constants.PrefabsPath + "WallPrefab");

        SetUpBuilding();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void SetUpBuilding()
    {
        var minX = this.transform.position.x;
        var minZ = this.transform.position.z;

        for (float x = minX; x < minX + buildingSize; x++)
        {
            for(float z = minZ; z < minZ + buildingSize; z++)
            {
                if(x == minX || x == (minX + buildingSize) - 1)
                {
                    //wall
                    var newWall = Instantiate(wallPrefab, new Vector3(x, 0.1f, z), Quaternion.Euler(0.0f, 90.0f, 0.0f));
                    newWall.transform.parent = this.transform;
                }
                else if(z == minZ || z == (minZ + buildingSize) - 1)
                {
                    //wall
                    var newWall = Instantiate(wallPrefab, new Vector3(x, 0.1f, z), Quaternion.identity);
                    newWall.transform.parent = this.transform;
                }
                else
                {
                    //floor
                    var newFloor = Instantiate(floorPrefab, new Vector3(x, 0.1f, z), Quaternion.identity);
                    newFloor.transform.parent = this.transform;
                }
            }
        }
    }
}
