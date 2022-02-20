using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellEnemy : SimpleEnemy
{



	public GameObject shellPrefab;
	public float rotatingSpeed = 180f;
	


	// Use this for initialization
	override protected void Start()
	{
		base.Start();
	}



	
	// Update is called once per frame
	override protected void Update()
	{
		base.Update();

	}

    protected override void OnKill()
    {
        base.OnKill();
		
		//------GameObject  ShellObject is creating a refrence to Shellprefab in the instantiate method
		GameObject shellObject = Instantiate(shellPrefab);
		shellObject.transform.position = transform.position + new Vector3 (0, -0.92f, 0);
		shellObject.transform.parent = transform.parent;

    }







}
