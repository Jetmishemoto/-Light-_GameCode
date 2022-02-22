using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{

    // This adds Target box in the Unity Inspector--Enableing you to fix a target for camera once you drop game object in the box
    public Playa playa;

   //Adds Cam offset Method for Unity inspector 
   //--- This enables you to offsets the camera---
    public Vector3 offset;
    public float speed = 5f;	
	
	// Update is called once per frame-------------------------------------------------------------------------------------------

       //Fixedupdate is updated with the players pysics       
	void FixedUpdate () 
    {

        //Adds Cam follow Method for Unity inspector --- 
        //Centers camra on player and use *Time.deltaTime); to smooth out animetion-- 
                                                                //--Place + offset here for the camra--      
        if (playa.Dead == false && playa.Finished == false)
        {
            Vector3 targetPosition = new Vector3(playa.transform.position.x + offset.x, playa.transform.position.y + offset.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }

	}
}               
