using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Playa playa;
    private Animator _anim;
    private AnimatorStateInfo currentStateInfo_0;


    
    public GameObject swordPrefab;


    int isJumpingHash;
    int _valocityHash;
    int _idlefloatHash;
    int _neutralIdleHash;
    int _normalIdleHash;
    int mainLayer;




    void Awake()
    {
       
        playa = GetComponent<Playa>();
        _anim = GetComponent<Animator>();



        swordPrefab = GameObject.FindGameObjectWithTag("Sword");
        

        isJumpingHash = Animator.StringToHash("isJumping");
        _valocityHash = Animator.StringToHash("Velocity");
        _idlefloatHash = Animator.StringToHash("idle_float");
        _neutralIdleHash = Animator.StringToHash("Neutral_Idle");
        _normalIdleHash = Animator.StringToHash("Normal_Idle");



         mainLayer =_anim.GetLayerIndex("Main");
        

    }


    public void SetAnimBool(int hash, bool value)
    {
         _anim.SetBool(hash, value);
    }

    private void AnimationLayerMonitor()
    {


        // SwordLayer if()
        if (mainLayer == 0)
        {
            //print("main_layer");
            MeshRenderer swordRenderer = swordPrefab.GetComponent<MeshRenderer>();
            swordRenderer.enabled = false;
        }




    }



    private void IdleStatesMonitor()
    {

        if (_valocityHash > 0.1)
        {

            SetAnimBool(_idlefloatHash, false);
            SetAnimBool(_neutralIdleHash,false);
            SetAnimBool(_normalIdleHash,false);
        }



    }



    private void SwordAttackStateMonitor()
    {
        if (currentStateInfo_0.IsName(""))
        {
            //playa._canMove = false;

        }
        if (playa._canMove)
        {


            //print("CanMove");
        }


    }
    private bool JumpingStateMonitor()
    {
        if ( playa._Jumping == true )
        {
            _anim.SetBool(isJumpingHash, true);
        }
       

        return true;
    }





    void Update()
    {
        currentStateInfo_0 = _anim.GetCurrentAnimatorStateInfo(0);
        SwordAttackStateMonitor();
        IdleStatesMonitor();
        JumpingStateMonitor();
        AnimationLayerMonitor();
        

    }
}
