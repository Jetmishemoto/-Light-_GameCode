using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour {
	// Place the object you want to orbit in box on unity inspector
	public GameObject Orbit;

	public float speed = 10f;

	


	// Use this for initialization
	void Start () 
	{



		//rotateChange();


	}
	
	// Update is called once per frame
	void Update () {

		OrbitAround();


	}
	// This make the gameobject attaced to this script orbit another game object
	void OrbitAround()
    {
														//new Vector3 (xf, yf, zf) , speed * Time.deltaTime);
		transform.RotateAround(Orbit.transform.position, new Vector3 (20f, 30f, 10f) , speed * Time.deltaTime);

    }


	/*private IEnumerator rotateChange()
    {




    }*/




}
