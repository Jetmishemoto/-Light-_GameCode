using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Playa playa;
    
    private Animator _anim;
    private AnimatorStateInfo currentStateInfo_0;
   


    
    public GameObject swordPrefab;


     int attackinghash;
    int _swordAttackModeActivatedHash;
    int isJumpingHash;
    int _valocityHash;
    int _idlefloatHash;
    int _neutralIdleHash;
    int _normalIdleHash;

    int mainLayer;


    [SerializeField] float swordModeTimer = 0f;
     [SerializeField] float swordModeDuration = 15f;
    [SerializeField] bool swordModeActivated = false;


    float swordModeTime = 1f;
    


    int _isRunningHash;

    private bool attackAnimation;




    void Awake()
    {

        swordModeActivated = false;
       
        playa = GetComponent<Playa>();
       
        _anim = GetComponent<Animator>();



        swordPrefab = GameObject.FindGameObjectWithTag("Sword");
        

        isJumpingHash = Animator.StringToHash("isJumping");
        _valocityHash = Animator.StringToHash("Velocity");
        _idlefloatHash = Animator.StringToHash("idle_float");
        _neutralIdleHash = Animator.StringToHash("Neutral_Idle");
        _normalIdleHash = Animator.StringToHash("Normal_Idle");
        attackinghash = Animator.StringToHash("Attacking");
        _swordAttackModeActivatedHash = Animator.StringToHash("Sword_Attack_Mode_Activated");


            


        _isRunningHash = Animator.StringToHash("_isRunning");
;

         mainLayer =_anim.GetLayerIndex("Main");
        

         
        

    }




    void Update()
    {
        currentStateInfo_0 = _anim.GetCurrentAnimatorStateInfo(0);

        SwordAttackStateMonitor();
        OrbAttackStateMonitor();
        IdleStatesMonitor();
        JumpingStateMonitor();
        AnimationLayerMonitor();
      


    }





    private IEnumerator PauseAnimationPlaying()
    {
        attackAnimation = false;
        //Same as P_attack.PreventSpam();
        yield return new WaitForSeconds(0.7f);
        attackAnimation = true;

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

        if (_valocityHash == 0.01)
        {

            print("moveing");
            print(_valocityHash);
            SetAnimBool(_idlefloatHash, false);
            SetAnimBool(_neutralIdleHash,false);
            SetAnimBool(_normalIdleHash,false);
        }



    }



    private void SwordAttackStateMonitor()
    {
        bool pressingSwordAttackButton = Input.GetKeyDown(KeyCode.K);

        if (playa.IsGrounded()
            && pressingSwordAttackButton)
        {
            
            SetAnimBool(_swordAttackModeActivatedHash, true);
            swordModeActivated = true;
            //print("swordAttackModeActivated");
            
            
           
        }


        if (swordModeActivated == true)
        {
            swordModeTimer += swordModeTime * Time.deltaTime;
        }

        if(swordModeActivated 
            && swordModeTimer > swordModeDuration)
        {
            SetAnimBool(_swordAttackModeActivatedHash, false);
            swordModeActivated = false;
            swordModeTimer = 0f;

        }



        //if (currentStateInfo_0.IsName(""))
        //{
        //    //playa._canMove = false;

        //}
        //if (playa._canMove)
        //{


        //    //print("CanMove");
        //}


    }



    private void OrbAttackStateMonitor()
    {
        bool pressingFireButton = Input.GetKeyDown(KeyCode.J);

        if (pressingFireButton)
        {
            print("attack");
            SetAnimBool(attackinghash, true);
            StartCoroutine(PauseAnimationPlaying());

        }
        else SetAnimBool(attackinghash, false);
    }


    private bool JumpingStateMonitor()
    {
        if (playa.IsGrounded()
            && playa._Jumping == true )
        {
            SetAnimBool(_isRunningHash, false);
            _anim.SetBool(isJumpingHash, true);
        }
       

        return true;
    }




}
