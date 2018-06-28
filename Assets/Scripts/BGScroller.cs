using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

    public float scrollSpeed; // input in the inspector that sets the rate that the background scrolls.
    public float tileSizeZ; // input where you enter the size in the z axis of the image that you are scrolling through

    private Vector3 startPosition; //variable for storing the initial x,y,z position of the background

    // Use this for initialization
	void Start () {
        startPosition = transform.position; //initialises the value for start position
	}
	
	// Update is called once per frame
	void Update ()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ); 
        transform.position = startPosition + Vector3.forward * newPosition; /*loops, when the tilesize is exceeded
        the background snaps back to its initial position effectively creating an infinite loop*/
    }
}
