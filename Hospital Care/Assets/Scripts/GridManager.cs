using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    public float SizeOfGrid = 1.0f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    public Vector3 GetNearestGridPoint(Vector3 rayPosition)
    {
        rayPosition -= transform.position;

        int xCount = Mathf.RoundToInt(rayPosition.x / SizeOfGrid);
        int yCount = Mathf.RoundToInt(rayPosition.y / SizeOfGrid);
        int zCount = Mathf.RoundToInt(rayPosition.z / SizeOfGrid);

        Vector3 result = new Vector3((float)xCount * SizeOfGrid, (float)yCount * SizeOfGrid, (float)zCount * SizeOfGrid);

        result += transform.position;

        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for(float x = this.transform.position.x; x < this.transform.position.x + 40; x += SizeOfGrid)
        {
            for(float z = this.transform.position.z; z < this.transform.position.z + 40; z += SizeOfGrid)
            {
                var point = GetNearestGridPoint(new Vector3(x, 0.0f, z));
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
    }
}
