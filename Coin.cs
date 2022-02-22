using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{

	//This is the references to Gameobject this script is attaced too, it will be called later in the script
	public GameObject model;
	public GameObject effectPrefab;


	//				VARIABLE
	//	Also adds rotatingspeed to the Unity inspector  to be later changed.
	// The -variable- that defines the rotation speed  of the coin model	  
	public float rotatingSpeed = 30f;






	// Update is called once per frame--------------------------------------------------------------------------------------- |Update Methods|
	void Update ()
	{
		//This logic calls the reference gameObject
		//Make object rotateAround an axes 3 parameters defined by (code)--- 
		model.transform.RotateAround(model.transform.position, Vector3.up, rotatingSpeed * Time.deltaTime);
	}



	//  This makes the object dissapear 
	 public virtual void Vanish ()
	{
		
		
		StartCoroutine (VanishRoutine ());

	}



	//Modify the vanish Routine
	protected virtual IEnumerator VanishRoutine ()
	{   
		
		// This add a timer to the VansishRoutine. 		
		yield return new WaitForSeconds(0.8f);
		Destroy(this.gameObject);

    }

	public void onCoinCollected()
    {

		GameObject effectobject = Instantiate(effectPrefab);
		effectobject.transform.SetParent(transform.parent);
		effectobject.transform.position = (transform.position);
    }

}
