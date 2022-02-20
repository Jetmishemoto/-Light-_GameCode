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


  
    public bool attackReady = false;
    public bool paused = false;
    public bool _canAttack = false;
    public bool _recharging = false;

    public  int attackChanes;
    public  int _lightCount;

    public  float _rechargeTime = 0f;
    public float _rechageDuration = 5f;
    public bool _rechargeFinished;


    public float _attackTimer;
    [SerializeField] private bool attacking;
    public bool attackAnimationReady;
    Coroutine rechargeRoutine;

    public void Start()
    {
       //_attackTimer = Time.time;
        _canAttack = false;
        attacking = false;
        _rechargeFinished = false;
        
     
    }



    // Update is called once per frame--------------------------------------------------   | Player Input |
    public void Update()
    {
       //_attackTimer += Time.deltaTime;

        if (_lightCount >= 3)
        {
            attackReady = true;
            attackAnimationReady = true;
        }
       
        if (attackChanes <= 0)
        {
            _canAttack = false;
            attackAnimationReady = false;
        }
        
        if (attackChanes == _lightCount)
        {
            _canAttack = true;

        }

        if (attackChanes < 0)
        {
            attackChanes = 0;
        }


        if (_canAttack)
        {
            LightAttack();
        }


        if (attackChanes == 0)
        {
            _rechargeTime += Time.deltaTime;
           rechargeRoutine =  StartCoroutine(Recharge());
        }
        if (rechargeRoutine != null
            && _recharging == false
            && _rechargeTime >= 5f)
        {
            StopAllCoroutines();
            _rechargeTime = 0f;
        }


        if (_rechargeFinished == true)
        {
            _canAttack = true;
            attackChanes = _lightCount;
            _rechargeFinished = false;
        }



    }


    public void OnCollectedLight()
    {
        _lightCount++;
        attackChanes++;
     
    }


    public void LightAttack()
    {

        if (attackChanes == 0 
            && _recharging == true) return;
     
        else if (Input.GetKeyDown(KeyCode.J)
           && attackReady == true
           && paused == false
           && _recharging == false)
        {
            attacking = true;
            attackAnimationReady = true;
            attackChanes--;
            StartCoroutine(PreventSpam());

            _attackOrb.thrown = true;
            GameObject _Light = Instantiate(_lil_Light,
            transform.position + (transform.right * 1),
            transform.rotation);
            _Light.GetComponent<Rigidbody>().AddForce(transform.right * 2500);

        }
        else return;
       
    }



    IEnumerator PreventSpam()
    {
        attackReady = false;
        paused = true;
        _canAttack = false;
        attacking = false;
        attackAnimationReady = false;
    //Controls the player attack Timeing(0.7) OGtime
        yield return new WaitForSeconds(0.7f);
        _canAttack = true;
        attackReady = true;
        paused = false;
        

    }


    IEnumerator Recharge()
    {

        _recharging = true;

        attackReady = false;
        _canAttack = false;
        //print("recharge");
        // ---------------------------------  5f
        yield return new WaitForSeconds(_rechageDuration);
        //print("recharge_fin");
        _recharging = false;
        _rechargeFinished = true;

    }




}
