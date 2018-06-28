using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour // I put this class on bolts because some were escaping the boundary
    //when the enemy would fire just as it was leaving the screen. This script ensures that all the bolts 
    // are destroyed after a certain amount of time lifetime.
{
    public float lifetime; // has to  be set to a high enough value so that bolts don't disappear before 
    // reaching the edge of the screen

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}