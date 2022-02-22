using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Main_Orbit_Area : MonoBehaviour
{

    public GameObject[] c_light;

    public P_LightAttack p_Attck;
    public Playa _playa;
    public Light_inOrbit _InOrbit;

    public GameObject orbitTarget;
    public Transform playa;


    IEnumerator tOrb;

    Coroutine orbRcharge;


    [SerializeField] Vector3 orbitTilt;


    // Start is called before the first frame updates
     void Start()
     {
        tOrb = ThrowOrb();
        
        c_light = GameObject.FindGameObjectsWithTag("O_Ball");

        this.gameObject.transform.rotation = Quaternion.Euler(orbitTilt);
        
     }




    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)
            && p_Attck.attackReady == true
            && p_Attck._canAttack == true
            && p_Attck._recharging == false)
        {
           
            StartCoroutine(tOrb);

        }
        else StopCoroutine(tOrb);


        if (p_Attck.attackChanes <= 0
            && p_Attck._canAttack == false
            && p_Attck._recharging == true)
        {
           orbRcharge =  StartCoroutine(OrbRcharge());
        }
        else
        {
           
           StopCoroutine(OrbRcharge());
        }

        this.transform.position = orbitTarget.transform.position;
    }




    IEnumerator ThrowOrb()
    {

        while (p_Attck.attackReady)
        {

            for (int i = 0; i < c_light.Length; i++)
            {
                if (c_light[i].GetComponent<Light_inOrbit>().inOrbit == true)
                {

                    MeshRenderer meshRenderer = c_light[i].GetComponent<MeshRenderer>();
                    meshRenderer.enabled = false;
                    //print("Started");
                    print("orb" + i);
                    yield return new WaitForSeconds(0.7f);
                    

                }


            }
        }
       
    }



    IEnumerator OrbRcharge()
    {
        if(p_Attck._recharging == true)
        {

            for (int i = 0; i < c_light.Length; i++)
            {
                if (c_light[i].GetComponent<Light_inOrbit>().inOrbit == true)
                {
                     
                    MeshRenderer meshRenderer = c_light[i].GetComponent<MeshRenderer>();
                    meshRenderer.enabled = true;
                    //print("recharging");
                    yield return new WaitForSeconds(0.8f);
                    yield return null;

                }
            }

        }

    }


  
}
