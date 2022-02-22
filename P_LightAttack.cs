using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_LightAttack : MonoBehaviour
{


    public Playa _playa;
    public Main_Orbit_Area _Orbit_Area;
    public GameObject _lil_Light;
    [SerializeField] P_LightAttack p_LightAttack;
    public  Lil_AttackOrb _attackOrb;


  
    public bool attackReady;
    public bool _canAttack = false;
    public bool _recharging = false;

    public  int attackChanes;
    public  int _lightCount;

    public  float _rechargeTime = 0f;
    public float _rechageDuration = 5f;

    public float _attackTimer;
   

      






    public void Awake()
    {
        _attackTimer = Time.time;
        attackReady = true;
        
     
    }



    // Update is called once per frame--------------------------------------------------   | Player Input |
    public void Update()
    {
        _attackTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.J)
            && attackReady
            && _canAttack == true
            && attackChanes > 0){
            StartCoroutine(PreventSpam());
            LightAttack();
            _attackTimer = 0;
        }


        if(attackChanes <= 0
           &&_canAttack == false)
        {
            StartCoroutine(Recharge());
        }
        else
        {
            StopCoroutine(Recharge());
        }

    }


    public void OnCollectedLight()
    {
        _lightCount++;
        attackChanes++;

        if (_lightCount >= 3
            && attackChanes > 0
            && _recharging == false)
        {
            _canAttack = true;
        }
        else
        {

            _canAttack = false;
        }


    }


    public void LightAttack()
    {
        _attackOrb.thrown = true;
        attackChanes--;
        GameObject _Light = Instantiate(_lil_Light,
        transform.position + (transform.right * 1),
        transform.rotation);
        _Light.GetComponent<Rigidbody>().AddForce(transform.right * 2500);
    }



    IEnumerator PreventSpam()
    {
        attackReady = false;
        _canAttack = false;
    //Controls the player attack Timeing(0.7) OGtime
        yield return new WaitForSeconds(0.7f);
        _canAttack = true;
        attackReady = true;

    }




    IEnumerator Recharge(){

        _recharging = true;
        _canAttack = false;

        yield return new WaitForSeconds(_rechageDuration);
        attackChanes = _lightCount;
        _canAttack = true;
        _recharging = false;

    }




}
