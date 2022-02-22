using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour 
{
	
	
	// Make sure to CAP GameObject when referning

	public GameObject destroyer_target;
	private Playa playa;

	// Use this for initialization-----------------------------------------------------------
	void Start () 
	{

		playa = GetComponent<Playa>(); 

	}

	// Update is called once per frame-----------------------------------------------------
	void Update() 
	{
		

		

	}


		// Finds if the player has hit this object ------------------------------------------------------
		void OnTriggerEnter (Collider otherCollider) 
		{

			// Only works if the script is contaned with in the the gameobject
			// This asks if the player has collided with the the destroyer area

			if (otherCollider.transform.GetComponent <Playa> () != null)
            {
//				---------Calls a method from a deffrent scritp so you can run it in if stament but you can assine it to a variable---> SendMessage (MeathodName);
				destroyer_target.SendMessage ("OnKill");

				// if the player has collided with this object destroy it 
				Destroy (destroyer_target.gameObject);

				// Make sure to add Brick or whatever the contaner of the script is as the target in Unity Inspector
            }
        }
		
}

