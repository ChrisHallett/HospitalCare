using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    private GridManager gridObject;

    // Use this for initialization
    void Start()
    {
        gridObject = FindObjectOfType<GridManager>();
        if (gridObject == null)
        {
            Debug.LogError("Could not find grid manager, please ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit rayHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //if we clicked near something
            if (Physics.Raycast(ray, out rayHit))
            {
                //Place on the grid
                PlaceObjectNear(rayHit.point);
            }
        }
    }

    private void PlaceObjectNear(Vector3 rayPoint)
    {
        var gridPosition = gridObject.GetNearestGridPoint(rayPoint);
        GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = gridPosition;
    }
}
