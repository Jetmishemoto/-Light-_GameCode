using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lil_AttackOrb : MonoBehaviour
{

    public Transform startPos;
    public Transform playerPos;



    public bool thrown = false;
    [SerializeField] float throwTime = 0;

    private float _accelTime = 5;
    [SerializeField] float dist = 0f;
    float lerpSpeed = 3f;

       

    public bool hit = false;
    public bool returning = false;




    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("C-Orbit_Target").transform;
    }

    public void ReturnToPlayer ()
    {

        thrown = true;
        //Debug.Log("thrown");

       

        if (thrown && throwTime > 1.8)
        {
            Rigidbody rigid;
            rigid = GetComponent<Rigidbody>();
            rigid.useGravity = false;
            rigid.isKinematic = true;
            returning = true;
           
            if (returning)
            {
                 thrown = false;
                this.transform.position = Vector3.Lerp(startPos.position,
                playerPos.position,
                dist * Time.deltaTime * lerpSpeed);
                dist = 1f;

            }

            //Debug.Log("retuning");

        }
    
    
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Playa>() != null)
        {
            thrown = false;
            returning = false;
            Destroy(this.gameObject);
        }

    }



    void Update()
    {
         
         ReturnToPlayer();
        if (thrown)
        {
            throwTime += _accelTime * Time.deltaTime;
           
        }


        if (throwTime >= 30)
        {
            throwTime -= _accelTime * Time.deltaTime;
        }
    }

   
}
