using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBack : MonoBehaviour {


  

    //Adds Methods for Unity inspector ---
    //Enables you adjust the physics listed here in the unity inspector---
    public float movementSpeed = 4f;
    public float acceleration = 2.5f;
    public float speed;

    // Use this for initialization
    void Start () 
    {
		






	}
	
	// Update is called once per frame
	void Update () 
    {

  
        GetComponent<Rigidbody> ().velocity = new Vector3
            
            (GetComponent<Rigidbody>().velocity.x,
            GetComponent<Rigidbody>().velocity.y,
            GetComponent<Rigidbody>().velocity.z);


        speed += acceleration * Time.deltaTime;
        if (speed > movementSpeed)
        {
            speed = movementSpeed;
        }

        GetComponent<Rigidbody>().velocity = new Vector3
            (
            speed,
            GetComponent<Rigidbody>().velocity.y,
            GetComponent<Rigidbody>().velocity.z
            );
    }


   









}
