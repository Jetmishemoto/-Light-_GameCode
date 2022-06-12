using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWeapon4 : MonoBehaviour
{

    

    // Sets the Player attack script in memmory so we can accces its methods
    public P_LightAttack _LightAttack;
    
      public Light_inOrbit _InOrbit;

    public Transform orbit;
    public GameObject _playa;


    public Transform startorbit;
    public Transform endOrbit;


    public float lerpPct = 0f;
    private bool _collected = false;




    void Update()
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
            lerpPct * Time.deltaTime);
        lerpPct = 1f;


    }
    public void IsCollected()
    {
        _collected = true;
        GetComponent<SphereCollider>().enabled = false;  
        transform.parent = GameObject.Find("C-Orbit 4").transform;
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
