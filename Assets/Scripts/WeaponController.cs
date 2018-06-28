using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
	}

    void Fire()/*instantiates shots for the enemies constantly repeats for the life of the object
        starts after a delay
        fires ata rate set by fire rate */
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audioSource.Play();
    }
	
}
