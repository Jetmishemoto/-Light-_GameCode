using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// --- This connects 2 scripts togther,  calling one of them will call both. 
/*Enemy and SimpleEnemy classes affect oneanother 
 * |
 * |
 * |
 * V
			Patrollingenemy is the child and Enemy is parent  *///------------------------------------------------
public class Patrollingenemy : Enemy
{


	public float speed = 3f;
	public float movementAmplitude = 4f;


	private Vector3 initialPositiion;
	private bool movingLeft = true;

	// Use this for initialization
	protected virtual void Start()
	{

		/*



		 */
		initialPositiion = transform.position;



	}

	// Update is called once per frame
	protected virtual void Update()
	{


		transform.position = new Vector3(
			transform.position.x + speed * Time.deltaTime * (movingLeft ? -1 : 1),
			transform.position.y,
			transform.position.z

			);

		if (movingLeft == true && transform.position.x < initialPositiion.x - movementAmplitude / 2)
		{
			movingLeft = false;


		}

		else if (movingLeft == false && transform.position.x > initialPositiion.x + movementAmplitude / 2)
		{
			movingLeft = true;


		}





	}
}
