using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWeapon : MonoBehaviour
{

   

    // Sets the Player attack script in memmory so we can accces its methods
    public P_LightAttack _LightAttack;
    
    public Light_inOrbit _InOrbit;

    public Transform startorbit;
    public Transform endOrbit;
    public GameObject _playa;



    public float lerpPct = 0f;
    private bool _collected = false;



    private void Update()
    {
        if (_collected)
        {
            MoveToOrbit();
        }

    }


    private void MoveToOrbit()
    {
        transform.position = Vector3.Lerp(startorbit.position,
            endOrbit.position,
            lerpPct * Time.deltaTime) ;
            lerpPct = 1f;


    }

    public void IsCollected()
    {
        _collected = true;
        GetComponent<SphereCollider>().enabled = false;  
        transform.parent = endOrbit.transform;
        MoveToOrbit();
        _InOrbit.inOrbit = true;

    }

    public void OnTriggerEnter(Collider other_Col)
    {
        
        if (other_Col.CompareTag( "Player"))
        {
           _LightAttack.OnCollectedLight();        
            IsCollected();
           

        }

    }









}
