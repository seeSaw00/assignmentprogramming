using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax; //inputs for edges of the gameplay screen

}
public class PlayerController : MonoBehaviour
{
    public float speed; //public floats can be given values in the inspector
    public float tilt; // input that sets the rate of tilt when the ship is moved sideways
    public Boundary boundary;
    private Rigidbody rb; //sets a local variable rb of type rigidbody
    private AudioSource audioSource;
    public GameObject shot; //creates a slot in the inspector that can be filled with the bolt prefab
    public Transform shotSpawn;  //creates a transform component that is a child of player, slightly offset so that the bolts come out of the front of the ship
    public float fireRate; //input in the inspector that sets the time between consecutive shots

    private float nextFire; //this variable is used to see if the time elapsed is greater than previous time.time plus the fire rate.

    void Update ()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire )//conditional statement that decides if enough time has elapsed since previous shot.
        
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);//instantiates a shot game object with the shotspawn transforms.
            audioSource.Play();
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        


    }
    void FixedUpdate()// fixed update is used instead of update when dealing with rigidbody components
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
       (
            Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), //stops the player from going off the screen in the x axis
            0.0f,
            Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)// stops the player from going off the screen or too far up the screen in z axis, or up and down when viewed through the game camera.
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt); //causes the rigidbody to rotate along the z axis by a factor of x velocity times tilt, which is set in the inspector
    }
}

