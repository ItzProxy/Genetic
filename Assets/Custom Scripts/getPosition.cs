using UnityEngine;
using System.Collections;

public class getPosition : MonoBehaviour {
    private Camera main;
    GameObject player;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        main = Camera.current;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        try
        {
            if (GameObject.Find("FullBody") == null)
            {
                player = GameObject.Find("FullBody");
                offset = transform.position - player.transform.position;
            }
            else
            {
                transform.position = player.transform.position + offset;
            }
        }
        catch
        {
            
        }
	}
}
