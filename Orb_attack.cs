using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb_attack : MonoBehaviour
{




    public Lil_AttackOrb _attackOrb;
    public P_LightAttack p_LightAttack;

     public GameObject _lil_Light;
     public Transform spawnPoint;



    // Start is called before the first frame update
    public void Awake()
    {
        _attackOrb = GetComponent<Lil_AttackOrb>();
        p_LightAttack = GetComponent<P_LightAttack>();
    }



    public void LightAttack()
    {
        Debug.Log("Attack pressed");
        _attackOrb.thrown = true;
        p_LightAttack.attackChanes--;
        GameObject _Light = Instantiate(_lil_Light,
        spawnPoint.position + (transform.right * 1),
        spawnPoint.rotation);
        _Light.GetComponent<Rigidbody>().AddForce(spawnPoint.right * 2500);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
