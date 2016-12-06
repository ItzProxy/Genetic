using UnityEngine;
using System.Collections;

public class FloorMatch : MonoBehaviour
{
    private GameObject floor;
    private Vector3 floorPos;
    private GameObject relativeFloorRef;
    private int camSize;
    // Use this for initialization
    void Start()
    {
        floor = GameObject.Find("Floor");
        floorPos = floor.transform.position;
        relativeFloorRef = GameObject.Find("Cube (1)");
    }

    // Update is called once per frame
    void Update()
    {
        if (floor != null)
        {
            floor.transform.localScale = new Vector3(6000F, 30F, 1F);
        }
    }
}
