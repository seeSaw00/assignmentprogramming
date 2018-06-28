using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion; // sets public variables for holding the explosion and playerExplosion prefabs.
    public GameObject playerExplosion;
    public int scoreValue; // an input for setting the value in points for the hazard being destroyed
    private GameController gameController; /* GameController is a public class defined in the GameController
    script. This piece of code sets a private variable of the type GameController */

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController"); /* sets a GameObject variable to 
        the value GameController - looks for the tag GameController */
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        } 
        // stores the GameController variable
        if (gameController == null) // if there is no gameController found then this error message appears
            // in the debug log
        {
            Debug.Log("Cannot find 'GameController' script");
        }

    }

    void OnTriggerEnter(Collider other) // when an object collides with something else 
    {
        if (other.CompareTag ("Boundary") || other.CompareTag ("Enemy")) //checks whether the other object is
            // the boundary or another enemy
        {
            return; // exits the function without anything being destroyed
        }

        if (explosion != null) /* instantiates an explosion GameObject at */
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.tag == "Player") /* if the other object being collided with is the player, then 
            it instantiates a player explosion as well and runs the function GameOver()*/
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        gameController.AddScore(scoreValue); // adds the score and destroys both collision objects
        Destroy(other.gameObject);
        Destroy(gameObject);
        }
    }
