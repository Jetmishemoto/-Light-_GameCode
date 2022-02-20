using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{





	public float rotatingSpeed = 180f;
	public float movementSpeed = 10f;
	public float radiusTolerance = 0.4f;
	private bool movingRight = true;



	// Use this for initialization
	void Start ()
	{
		


	}
	
	// Update is called once per frame
	void Update () 
	{
		// rotates the shell game object
		transform.RotateAround(transform.position, Vector3.up, rotatingSpeed * Time.deltaTime);

		/* moves the shell to the right after being hit----------
																		The (?) checks the true or false statement
										This checks if the shell is moveing right||| 1 for moveing right and -1 for moveing left in the x axes										
														|
														|
														|
														V
		 */
			transform.position = new Vector3(
			transform.position.x + movementSpeed * (movingRight ? 1 : -1 ) *Time.deltaTime,
			transform.position.y,
			transform.position.z
			);
	}
	//------------------------------------------------------------------------------------------------------------
	void OnTriggerEnter(Collider otherCollider) 
	{


		if (otherCollider.GetComponent<Enemy>())
		{
			/*
			  The if statment selects the class the destroy method will delate
			 Destroy is a Method that can be called from any script
				|
				|
				V				 */
			Destroy(otherCollider.gameObject);
		}

		else if (otherCollider.GetComponent<Destroyer>() != null || otherCollider.CompareTag("Destructable"))
	    {
			return;
		}

		
		
		else if (transform.position.x < otherCollider.transform.position.x && movingRight == true)
		{
		  movingRight = false;
		}
		else if (transform.position.x > otherCollider.transform.position.x && movingRight == false)
		{
		  movingRight = true;
		}

		
		


	}
	//-----------------------------------------------------------------------------------------------------------------

	void OnCollisionEnter(Collision collision)
	{
		
       

		  if (transform.position.y < collision.transform.position.y + radiusTolerance )
		  {


			 if (transform.position.x < collision.transform.position.x && movingRight == true)
			 {
				movingRight = false;
			 }
			 else if (transform.position.x > collision.transform.position.x && movingRight == false)
			 {
				movingRight = true;
			 }

		  }
		

	}






}
