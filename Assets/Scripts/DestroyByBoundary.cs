using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{

	void OnTriggerExit(Collider other) /*destroys the other game object involved in the collision
        when it leaves the boundaries of the game.*/
    {
        Destroy(other.gameObject);
    }
}
