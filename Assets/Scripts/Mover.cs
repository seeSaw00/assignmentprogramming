using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// this script is used to move a few things in the game, the hazards and the shots
public class Mover : MonoBehaviour
{
    public float speed; //input that sets the speed of the object being moved. 
    private Rigidbody rb; // sets a variable for the rigid body component to go into

    void Start ()
    {
        rb = GetComponent<Rigidbody>(); // grabs the rigidbody component and assigns it to the rb variable
        //which was created as a Rigidbody type
        rb.velocity = transform.forward * speed; /* sets the velocity of rb to a value which is (0,0,1)
        multiplied by the public float speed which is set in the inspector so that you can easily adjust the 
        value. */
        /* effectively moves the spaceship down the screeen at a rate controlled by speed*/
    }
	
}
